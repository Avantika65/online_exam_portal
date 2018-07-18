<%@ Page Language="C#" AutoEventWireup="true" CodeFile="st_login.aspx.cs" Inherits="st_login" %>

<!DOCTYPE html>
<html>
    <head>
    	<title>
    	</title>
    	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8"/>
        <meta name="viewport" content="width=device-width, initial-scale=1"/>
    	 <!-- Compiled and minified CSS -->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
       <link href="css/materialize.css" type="text/css" rel="stylesheet" media="screen,projection"/>
      <link href="css/style.css" type="text/css" rel="stylesheet" media="screen,projection"/>
	  <!--Import Google Icon Font-->
      <link href="https://fonts.googleapis.com/icon?family=Material+Icons" rel="stylesheet">
      <!--Import materialize.css-->
      <link type="text/css" rel="stylesheet" href="css/materialize.min.css"  media="screen,projection"/>

      <!--Let browser know website is optimized for mobile-->
      <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
  <!--Import jQuery before materialize.js-->
      <script type="text/javascript" src="https://code.jquery.com/jquery-3.2.1.min.js"></script>
      <script type="text/javascript" src="js/materialize.min.js"></script>
       <script src="https://code.jquery.com/jquery-2.1.1.min.js"></script>
		  <script src="js/materialize.js"></script>
		  <script src="js/init.js"></script>

       <script type="text/javascript">

           function openmodel() {
               document.getElementById("modal1").style.backgroundColor = "white";
               document.body.style.backgroundColor = "white";
           }

         

           $(document).ready(function () {
               // body...
               // Initialize collapse button
               //$(".button-collapse").sideNav();
               // Initialize collapsible (uncomment the line below if you use the dropdown variation)
               //$('.collapsible').collapsible();
               $('.button-collapse').sideNav({
                   menuWidth: 250, // Default is 300
                   edge: 'left', // Choose the horizontal origin
                   closeOnClick: true, // Closes side-nav on <a> clicks, useful for Angular/Meteor
                   draggable: true, // Choose whether you can drag to open on touch screens,
                   //onOpen: function(el) { alert('Open'); }, // A function to be called when sideNav is opened
                   //onClose: function(el) { alert('Close'); }, // A function to be called when sideNav is closed
                   // the "href" attribute of the modal trigger must specify the modal ID that wants to be triggered

               });

           });
           $(document).ready(function () {
               $('#carousel.carousel-slider').carousel({ fullWidth: true }
                 );
           });
           $(document).ready(function () {
               $('#carousel').carousel();
               setInterval(function () {
                   $('#carousel').carousel('next');
               }, 3000);
               $('.carousel').carousel('next');
               $('.carousel').carousel('prev');

               $('.next').click(function () {
                   $('#carousel.carousel-slider').carousel('next');
               });
               $('.prev').click(function () {
                   $('#carousel.carousel-slider').carousel('prev');
               });
               $('.modal').modal();
               $('#modal1').modal('open');
               $('#modal1').modal('close');
               $('.model').model(
                   { active: true }
               );
           });
		</script>   
        <style>
            .model {
            background-color:white;
            enable-background:initial;
            }
        </style>
	</head>
	<body id="main">
		<div class="navbar-fixed">
			<nav class="black fixed" role="navigation">
			    <div class="nav-wrapper">
			      <a href="#"><i class="material-icons button-collapse" data-activates="nav-mobile" >menu</i></a>		    	
			      <a id="logo-container" href="#" class="brand-logo">Logo</a>
			      <ul class="right hide-on-med-and-down" style="text-align: right;">
			        <li><a href="hn.html">Home</a></li>
			        <li><a href="#">Contact Us</a></li>
			        <li>  <a class="waves-effect waves-light btn"  href="Login.aspx">SignIn</a></li>

			      </ul>

			    
			    </div>
                 
	  		</nav>
	  	</div>	
  		<div class="section no-pad-bot" style="background-image: url(images/6.jpg);">
		      <div class="container">
		        <h2 class="header center black-text text-lighten-2">Apply for QUIZ and Learn</h2>
		        <div class="row center">
		          <h5 class="header col s12 light" style="color: black; font-weight: bold;">Under experienced Technical Supervision</h5>
		        </div>
		        <div class="row center">
		          <a id="download-button" class="btn-large waves-effect waves-light black lighten-1" href="St_SignUp.aspx">Register As A Student</a>
                  <a id="A1" class="btn-large waves-effect waves-light black lighten-1" href="Fa_SignUp.aspx">Register As A Faculty</a>

		        </div>
		      </div>
		      <br><br>
		  </div>


         <div class="section">
		      <!--   Icon Section   -->
		      <div class="row">
			        <div class="col s12 m4">
			          <div class="icon-block">
			            <h2 class="center brown-text"><i class="material-icons">flash_on</i></h2>
			            <h5 class="center">Quick Learning</h5>
			            <p class="light">Get the basic knowledge enough to deging you own attractive web page</p>
			          </div>
			        </div>

			        <div class="col s12 m4">
			          <div class="icon-block">
			            <h2 class="center brown-text"><i class="material-icons">important_devices</i></h2>
			            <h5 class="center">Programming Languages</h5>
			            <p class="light">You can Learn C, C++, Core Java, PHP, SQL and all other programming languages and finally develop. </p>
			          </div>
			        </div>

			        <div class="col s12 m4">
			          <div class="icon-block">
			            <h2 class="center brown-text"><i class="material-icons">assignment</i></h2>
			            <h5 class="center">Online Test</h5>
			            <p class="light">Check your skills and then decide to learn or get certified by us.</p>
			          </div>
			        </div>
		      </div>
        </div>
     
		<%--<div class="carousel carousel-slider" id="Div1" data-indicators="true">
		    <a class="carousel-item" href="#one!"><img class="responsive-img" src="5.jpg" style="height: 300px;"/></a>
		    <a class="carousel-item" href="#two!"><img class="responsive-img" src="images/6.jpg" style="height: 300px;"/></a>
		    <a class="carousel-item" href="#three!"><img class="responsive-img" src="images/3.jpg" style="height: 300px;"/></a>
		    <a class="carousel-item" href="#four!"><img class="responsive-img" src="images/4.jpg" style="height: 300px;"/></a>
        </div>--%>

		<%--<div class="container">
		    <div class="section">
		        <div class="row">
			        <div class="col s12 center">
			          <h3><i class="mdi-content-send brown-text"></i></h3>
			          <h4>Contact Us</h4>
			          <p class="left-align light">In today's world of technologies its impotant to learn programming languages and designing.
			          We are providing knowledge to students thats free of cost and will be useful to them in futue.</p>
			        </div>
		        </div>
		    </div>
		</div>  --%>     

    <footer class="page-footer black">
		    <div class="container">
			      <div class="row">
				        <div class="col l6 s12">
					          <h5 class="white-text">All About Technologies</h5>
					          <p class="grey-text text-lighten-4">We are a team of college students working on this project like it's our full time job.</p>
				        </div>
				        <div class="col l3 s12">
					          <h5 class="white-text">Settings</h5>
					          <ul>
					            <li><a class="white-text" href="#!">Link 1</a></li>
					            <li><a class="white-text" href="#!">Link 2</a></li>
					          </ul>
				        </div>
				        <div class="col l3 s12">
					          <h5 class="white-text">Connect</h5>
					          <div class="row">
					            <div class="col l6 s6"><a class="white-text" href="#!">
					            	<img src="images\playstore.png" class="responsive-img" width="150" style="border-radius: 10px;">
					            </a></div>
					            <div class="col l6 s6"><a class="white-text" href="#!">
					            	<img src="images\microsoft.png" class="responsive-img" width="150" style="border-radius: 10px;">
					            </a></div>
					          </div>
				        </div>
				      </div>
			</div>
		    <div class="footer-copyright center">
		        <div>
		        	 Made by <a class="brown-text text-lighten-3" href="#">Psit Students </a>© 2018-QuizPortal
                 </div>
		    </div>
  </footer>
        
          <ul id="nav-mobile" class="side-nav" >
			      	 <li>
			      	 	<div class="user-view" style="height: 35%">
					      <div class="background">
					        <img class="responsive-img" src="images/p5.jpg">
					      </div>
					      <a href="https://www.linkedin.com/in/avantika-maurya-963347140/"><img class="responsive-img circle" src="images/avi.jpg" style="margin-top:50%;border: solid black 2.5px;"></a>
					      <a href="https://www.linkedin.com/in/avantika-maurya-963347140/"><span class="name" style="color:#1a237e  ;">Avantika-LinkedIN</span></a>
					    </div>
					</li>
					<li><a href="avantikanmaurya65@gmail.com"><span class="black-text email">avantikanmaurya65@gmail.com</span></a></li>
			        <li><a href="#">Home</a></li>
			        <li><a href="#">Contact Us</a></li>
			        <li>  <a class="waves-effect waves-light btn modal-trigger" data-activates="modal1" href="#modal1">SignUp</a></li>
			      </ul>
       
       
	</body>
</html>
