
App = function() {
    return {
        init : function() {
            
            Ext.BLANK_IMAGE_URL = 'http://extjs.cachefly.net/ext-3.1.0/resources/images/default/s.gif';
            this.calendarStore = new Ext.data.JsonStore({
                storeId: 'calendarStore',
                root: 'calendars',
                idProperty: 'id',
                data: calendarList, 
                proxy: new Ext.data.MemoryProxy(),
                autoLoad: true,
                fields: [
                    {name:'CalendarId', mapping: 'id', type: 'int'},
                    {name:'Title', mapping: 'title', type: 'string'}
                ],
                sortInfo: {
                    field: 'CalendarId',
                    direction: 'ASC'
                }
            });

      
            this.eventStore = new Ext.data.JsonStore({
                id: 'eventStore',
                root: 'evts',
                data: eventList, 
                proxy: new Ext.data.MemoryProxy(),
                fields: Ext.calendar.EventRecord.prototype.fields.getRange(),
                sortInfo: {
                    field: 'StartDate',
                    direction: 'ASC'
                }
            });

            new Ext.Viewport({
                layout: 'border',
                renderTo: 'calendar-ct',
                items: [{
                    id: 'app-header',
                    region: 'north',
                    height: 35,
                    border: false,
                    contentEl: 'app-header-content'
                },{
                    id: 'app-center',
                    title: '...',
                    region: 'center',
                    layout: 'border',
                    items: [{
                        id:'app-west',
                        region: 'west',
                        width: 176,
                        border: false,
                        items: [{
                            xtype: 'datepicker',
                            id: 'app-nav-picker',
                            cls: 'ext-cal-nav-picker',
                            listeners: {
                                'select': {
                                    fn: function(dp, dt){
                                        App.calendarPanel.setStartDate(dt);
                                    },
                                    scope: this
                                }
                            }
                        }]
                    },{
                        xtype: 'calendarpanel',
                        eventStore: this.eventStore,
                        calendarStore: this.calendarStore,
                        border: false,
                        id:'app-calendar',
                        region: 'center',
                        activeItem: 2, 
                     
                        monthViewCfg: {
                            showHeader: true,
                            showWeekLinks: true,
                            showWeekNumbers: true
                        },
                        
                        initComponent: function() {
                            App.calendarPanel = this;
                            this.constructor.prototype.initComponent.apply(this, arguments);
                        },
                        
                        listeners: {
                            'eventclick': {
                                fn: function(vw, rec, el){
                                    this.showEditWindow(rec, el);
                                    this.clearMsg();
                                },
                                scope: this
                            },
                            'eventover': function(vw, rec, el){
                              
                            },
                            'eventout': function(vw, rec, el){
                                
                            },
                            'eventadd': {
                                fn: function(cp, rec){
                                    this.showMsg('Event ' + rec.data.Title + ' was added');
                                   
                                },
                                scope: this
                            },
                            'eventupdate': {
                                fn: function(cp, rec){
                                    this.showMsg('Event ' + rec.data.Title + ' was updated');
                                   
                                },
                                scope: this
                            },
                            'eventdelete': {
                                fn: function(cp, rec){
                                    this.showMsg('Event '+ rec.data.Title +' was deleted');
                                },
                                scope: this
                            },
                            'eventcancel': {
                                fn: function(cp, rec){
                                   
                                },
                                scope: this
                            },
                            'viewchange': {
                                fn: function(p, vw, dateInfo){
                                    if(this.editWin){
                                        this.editWin.hide();
                                    };
                                    if(dateInfo !== null){
                                       
                                        Ext.getCmp('app-nav-picker').setValue(dateInfo.activeDate);
                                        this.updateTitle(dateInfo.viewStart, dateInfo.viewEnd);
                                    }
                                },
                                scope: this
                            },
                            'dayclick': {
                                fn: function(vw, dt, ad, el){
                                    this.showEditWindow({
                                        StartDate: dt,
                                        IsAllDay: ad
                                    }, el);
                                    this.clearMsg();
                                },
                                scope: this
                            },
                            'rangeselect': {
                                fn: function(win, dates, onComplete){
                                    this.showEditWindow(dates);
                                    this.editWin.on('hide', onComplete, this, {single:true});
                                    this.clearMsg();
                                },
                                scope: this
                            },
                            'eventmove': {
                                fn: function(vw, rec){
                                    rec.commit();
                                    var time = rec.data.IsAllDay ? '' : ' \\a\\t g:i a';
                                    this.showMsg('Event ' + rec.data.Title + ' was moved to ' + rec.data.StartDate.format('F jS' + time));
                                    alert("ok2");
                                },
                                scope: this
                            },
                            'eventresize': {
                                fn: function(vw, rec){
                                    rec.commit();
                                    this.showMsg('Event ' + rec.data.Title + ' was updated');
                                },
                                scope: this
                            },
                            'eventdelete': {
                                fn: function(win, rec){
                                    this.eventStore.remove(rec);
                                    this.showMsg('Event '+ rec.data.Title +' was deleted');
                                },
                                scope: this
                            },
                            'initdrag': {
                                fn: function(vw){
                                    if(this.editWin && this.editWin.isVisible()){
                                        this.editWin.hide();
                                    }
                                },
                                scope: this
                            }
                        }
                    }]
                }]
            });
        },
        
      
		showEditWindow : function(rec, animateTarget){
	        if(!this.editWin){
	            this.editWin = new Ext.calendar.EventEditWindow({
                    calendarStore: this.calendarStore,
					listeners: {
						'eventadd': {
							fn: function(win, rec){
								rec.data.IsNew = false;
								var Start_date = document.getElementById("date-range-start-date");
								var Start_time = document.getElementById("date-range-start-time");
								var End_time = document.getElementById("date-range-end-time");
								var End_Date = document.getElementById("date-range-end-date");
								var Chk_Allday = document.getElementById("date-range-allday");
								var calendar1 = document.getElementById("calendar");
							
								if (calendar1.value == "Holiday") {
								    if (Chk_Allday.checked == false) {
								        alert("Select All day In Holiday");
								        win.show();
								        return;
								    }
								    else {
								            $.ajax({
								                type: "POST",
								                contentType: "application/json; charset=utf-8",
								                url: "../Calender_details.asmx/insert_holiday_in_database",
								                data: "{'startdate':'" + Start_date.value + "','enddate':'" + End_Date.value + "','title':'" + rec.data.Title + "','leavetype':'" + calendar1.value + "'}",
								                dataType: "json",
								                success: function (data) {
								                    var obj = data.d;
								                    if (obj == 'true') {
								                        alert("Records Save Successfully........");
								                        
								                    }
								                },
								                error: function (result) {
								                    alert(result);

								                }
								            });
								            this.eventStore.add(rec);
								            win.hide();
								    }
								}
								if (calendar1.value == "Sunday") {
								    if (Chk_Allday.checked == false) {
								        alert("Select All day In Holiday");
								        win.show();
								        return;
								    }
								    else {
								        $.ajax({
								            type: "POST",
								            contentType: "application/json; charset=utf-8",
								            url: "../Calender_details.asmx/insert_holiday_in_database",
								            data: "{'startdate':'" + Start_date.value + "','enddate':'" + End_Date.value + "','title':'" + rec.data.Title + "','leavetype':'" + calendar1.value + "'}",
								            dataType: "json",
								            success: function (data) {
								                var obj = data.d;
								                if (obj == 'true') {
								                    alert("Records Save Successfully........");
								                  
								                }
								            },
								            error: function (result) {
								                alert(result);

								            }
								        });
								        this.eventStore.add(rec);
								        win.hide();
								    }
								}
							},
							scope: this
						},
						'eventupdate': {
							fn: function(win, rec){
								win.hide();
								rec.commit();
								alert("ok1");
								this.showMsg('Event ' + rec.data.Title + ' was updated');
							},
							scope: this
						},
						'eventdelete': {
							fn: function(win, rec){
								this.eventStore.remove(rec);
								win.hide();
                                this.showMsg('Event '+ rec.data.Title +' was deleted');
							},
							scope: this
						},
                        'editdetails': {
                            fn: function(win, rec){
                                win.hide();
                                App.calendarPanel.showEditForm(rec);
                            }
                        }
					}
                });
	        }
	        this.editWin.show(rec, animateTarget);
		},
        updateTitle: function(startDt, endDt){
            var p = Ext.getCmp('app-center');
            
            if(startDt.clearTime().getTime() == endDt.clearTime().getTime()){
                p.setTitle(startDt.format('F j, Y'));
            }
            else if(startDt.getFullYear() == endDt.getFullYear()){
                if(startDt.getMonth() == endDt.getMonth()){
                    p.setTitle(startDt.format('F j') + ' - ' + endDt.format('j, Y'));
                }
                else{
                    p.setTitle(startDt.format('F j') + ' - ' + endDt.format('F j, Y'));
                }
            }
            else{
                p.setTitle(startDt.format('F j, Y') + ' - ' + endDt.format('F j, Y'));
            }
        },
       
        showMsg: function(msg){
            Ext.fly('app-msg').update(msg).removeClass('x-hidden');
        },
        clearMsg: function(){
            Ext.fly('app-msg').update('').addClass('x-hidden');
        }
    }
}();

Ext.onReady(App.init, App);
