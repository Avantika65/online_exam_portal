IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Posts]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Posts](
	[PostID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Title] [nvarchar](255) NOT NULL,
	[Content] [nvarchar](max) NOT NULL,
	[Code] [nvarchar](255) NULL,
	[State] [smallint] NOT NULL CONSTRAINT [DF_Posts_State]  DEFAULT ((0)),
	[AddComment] [bit] NOT NULL CONSTRAINT [DF_Posts_AddComment]  DEFAULT ((1)),
	[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_Posts_CreateDate]  DEFAULT (getdate()),
	[ModifyDate] [datetime] NULL,
	[Type] [smallint] NOT NULL CONSTRAINT [DF_Posts_Type]  DEFAULT ((0)),
	[ReadCount] [int] NOT NULL CONSTRAINT [DF_Posts_ReadCount]  DEFAULT ((0)),
	[Show] [smallint] NOT NULL CONSTRAINT [DF_Posts_Show]  DEFAULT ((1)),
 CONSTRAINT [PK_Posts] PRIMARY KEY CLUSTERED 
(
	[PostID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Posts(UserID,Title,Content,Code,State,AddComment,Type) Values(1,'{post-title}','{post-content}','{post-code}',1,1,0)
INSERT INTO Posts(UserID,Title,Content,Code,State,Type,Show) Values(1,'{page-title}','{page-content}','{page-code}',1,1,0)
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Terms]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Terms](
	[TermID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](80) NOT NULL,
	[Description] [nvarchar](160) NULL,
	[Code] [nvarchar](80) NOT NULL,
	[Type] [nvarchar](12) NOT NULL CONSTRAINT [DF_Terms_Type]  DEFAULT (N'category'),
	[SubID] [int] NOT NULL CONSTRAINT [DF_Categories_SubID]  DEFAULT ((0)),
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[TermID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Terms(Name,Code,Type) Values('{category-title}','{category-code}','category')
INSERT INTO Terms(Name,Code,Type) Values('{tag-title}','{tag-code}','tag')
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Settings]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Settings](
	[SettingID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Value] [nvarchar](max) NOT NULL,
	[Title] [nvarchar](120) NULL,
	[Description] [nvarchar](max) NULL,
	[Main] [bit] NOT NULL CONSTRAINT [DF_Settings_Main]  DEFAULT ((0)),
	[Sort] [int] NOT NULL CONSTRAINT [DF_Settings_Sort]  DEFAULT ((0)),
	[Visible] [bit] NOT NULL CONSTRAINT [DF_Settings_Visible]  DEFAULT ((1)),
 CONSTRAINT [PK_Settings] PRIMARY KEY CLUSTERED 
(
	[SettingID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('blog_name','{setting-blogname}','BlogName',1,1,1,'BlogNameDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('blog_description','{setting-blogdescription}','BlogDescription',1,2,1,'BlogDescriptionDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('blog_url','{0}','BlogUrl',1,3,1,'BlogUrlDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('language','{1}','BlogLanguage',1,5,1,'BlogLanguageDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('theme','Classic','',1,6,0,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('permalink','0','BlogPermalink',1,9,1,'BlogPermalinkDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('permaexpression','{name}.html','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('show_post_count','10','BlogShowPostCount',1,10,1,'BlogShowPostCountDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('add_comment_approve','0','BlogAddCommentApprove',1,11,1,'BlogAddCommentApproveDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('recent_posts_count','5','BlogRecentPostCount',1,12,1,'BlogRecentPostCountDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('recent_comments_count','5','BlogRecentCommentsCount',1,13,1,'BlogRecentCommentsCountDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('pagingstyle','8','PagingStyle',1,14,1,'PagingStyleDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('paging','true','Paging',1,15,1,'PagingDescription')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('comment_sendmail','true','',1,16,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('feed_url','{0}feed.aspx','',1,17,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_name','example','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_email','example@example.com','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_server','mail.example.com','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_port','25','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_user','user@example.com','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_pass','password','',1,0,1,'')
INSERT INTO Settings(Name,Value,Title,Main,Sort,Visible,Description) Values('smtp_usessl','false','',1,0,1,'')
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TermsTo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TermsTo](
	[TermsToID] [int] IDENTITY(1,1) NOT NULL,
	[ObjectID] [int] NOT NULL,
	[TermID] [int] NOT NULL,
	[Type] [nvarchar](12) NOT NULL CONSTRAINT [DF_TermsTo_Type]  DEFAULT (N'category'),
 CONSTRAINT [PK_PostTo] PRIMARY KEY CLUSTERED 
(
	[TermsToID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO TermsTo(TermID,ObjectID,Type) Values(1,1,'category')
INSERT INTO TermsTo(TermID,ObjectID,Type) Values(2,1,'tag')
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](16) NOT NULL,
	[Password] [nvarchar](32) NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[Email] [nvarchar](255) NOT NULL,
	[WebPage] [nvarchar](255) NULL,
	[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_Users_CreateDate]  DEFAULT (getdate()),
	[LastLoginDate] [datetime] NULL,
	[State] [smallint] NOT NULL CONSTRAINT [DF_Users_State]  DEFAULT ((0)),
	[Role] [nvarchar](16) NOT NULL CONSTRAINT [DF_Users_Role]  DEFAULT (N'user'),
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Users(UserName,Password,Name,Email,State,Role) Values('admin','e10adc3949ba59abbe56e057f20f883e','Admin','example@example.com',10,'admin')
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Widgets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Widgets](
	[WidgetID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](160) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[FolderName] [nvarchar](160) NULL,
	[Type] [smallint] NULL,
	[Sort] [int] NOT NULL CONSTRAINT [DF_Addons_Sort]  DEFAULT ((0)),
	[Visible] [bit] NOT NULL CONSTRAINT [DF_Addons_Visible]  DEFAULT ((1)),
	[PlaceHolder] [nvarchar](50) NOT NULL CONSTRAINT [DF_Widgets_PlaceHolder]  DEFAULT (N'Default'),
 CONSTRAINT [PK_Addons] PRIMARY KEY CLUSTERED 
(
	[WidgetID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Widgets(Title,FolderName,Type,Sort,Visible,PlaceHolder) Values('{widget-feeder}','Feeder',0,0,1,'Default')
INSERT INTO Widgets(Title,FolderName,Type,Sort,Visible,PlaceHolder) Values('{widget-pages}','Pages',0,1,1,'Default')
INSERT INTO Widgets(Title,FolderName,Type,Sort,Visible,PlaceHolder) Values('{widget-categories}','Categories',0,3,1,'Default')
INSERT INTO Widgets(Title,FolderName,Type,Sort,Visible,PlaceHolder) Values('{widget-recentpost}','RecentPost',0,4,1,'Default')
INSERT INTO Widgets(Title,FolderName,Type,Sort,Visible,PlaceHolder) Values('{widget-recentcomment}','RecentComment',0,5,1,'Default')
INSERT INTO Widgets(Title,FolderName,Type,Sort,Visible,PlaceHolder) Values('{widget-links}','Links',0,6,1,'Default')
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Comments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Comments](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL CONSTRAINT [DF_Comments_UserID]  DEFAULT ((0)),
	[PostID] [int] NOT NULL,
	[Name] [nvarchar](60) NOT NULL,
	[Comment] [nvarchar](max) NOT NULL,
	[Email] [nvarchar](160) NOT NULL,
	[WebPage] [nvarchar](160) NULL,
	[Ip] [nvarchar](15) NOT NULL CONSTRAINT [DF_Comments_Ip]  DEFAULT (N'0.0.0.0'),
	[CreateDate] [datetime] NOT NULL CONSTRAINT [DF_Comments_CreateDate]  DEFAULT (getdate()),
	[Approve] [bit] NOT NULL CONSTRAINT [DF_Comments_Approve]  DEFAULT ((0)),
	[NotifyMe] [bit] NOT NULL CONSTRAINT [DF_Comments_NotifyMe]  DEFAULT ((0)),
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Links]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Links](
	[LinkID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Url] [nvarchar](160) NOT NULL CONSTRAINT [DF_Links_Url]  DEFAULT (N'#'),
	[Description] [nvarchar](max) NULL,
	[Target] [nvarchar](50) NOT NULL CONSTRAINT [DF_Links_Target]  DEFAULT (N'_self'),
	[TermID] [int] NOT NULL CONSTRAINT [DF_Links_TermID]  DEFAULT ((0)),
 CONSTRAINT [PK_Links] PRIMARY KEY CLUSTERED 
(
	[LinkID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
INSERT INTO Links(Name,Url,Description,Target) Values('Blogsa.Net','http://www.blogsa.net','Blogsa.Net','_blank')
END