SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[contact](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[author] [varchar](50) NOT NULL,
	[mail] [varchar](50) NOT NULL,
	[message] [text] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[families]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[families](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_families] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[family_patente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[family_patente](
	[family_id] [int] NOT NULL,
	[patente_id] [int] NOT NULL,
 CONSTRAINT [PK_family_patente] PRIMARY KEY CLUSTERED 
(
	[family_id] ASC,
	[patente_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[questions]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[questions](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](100) NOT NULL,
	[answer_id] [int] NULL,
	[state_id] [int] NOT NULL,
	[project_id] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_questions] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[services]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[services](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](50) NOT NULL,
	[service_type_id] [int] NOT NULL,
	[language_id] [int] NULL,
	[supplier_id] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_services] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[users]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[users](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DV]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DV](
	[table_name] [varchar](50) NOT NULL,
	[DV] [bigint] NOT NULL,
 CONSTRAINT [PK_DV] PRIMARY KEY CLUSTERED 
(
	[table_name] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Confluence_Backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Confluence_Backup]
AS
BEGIN
	BACKUP DATABASE Confluence TO DISK = N''c:\confluence.bak''
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Confluence_Restore]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[Confluence_Restore]
AS
BEGIN
RESTORE DATABASE Confluence FROM DISK = ''c:\confluence_restore.bak'' WITH REPLACE
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[projects]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[projects](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[description] [varchar](150) NULL,
	[date_start] [datetime] NOT NULL,
	[date_end] [datetime] NULL,
	[language_id] [int] NOT NULL,
	[owner_id] [int] NOT NULL,
	[developer_id] [int] NULL,
	[state_id] [int] NOT NULL,
	[publication_id] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_projects] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[clients]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
	[country] [varchar](20) NOT NULL,
	[state] [varchar](30) NULL,
	[phone] [int] NULL,
	[user_account] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_clientes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_family]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_family](
	[user_id] [int] NOT NULL,
	[family_id] [int] NOT NULL,
 CONSTRAINT [PK_user_family] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[family_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[studies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[studies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[institute] [varchar](50) NOT NULL,
	[study_level] [int] NOT NULL,
	[year_start] [int] NOT NULL,
	[year_end] [int] NULL,
	[client_id] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_studies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[user_patente]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[user_patente](
	[user_id] [int] NOT NULL,
	[patente_id] [int] NOT NULL,
 CONSTRAINT [PK_user_patente] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC,
	[patente_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[workxp]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[workxp](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[place] [varchar](50) NOT NULL,
	[year_start] [int] NOT NULL,
	[year_end] [nchar](10) NULL,
	[client_id] [int] NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_workxp] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[patentes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[patentes](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
	[path] [varchar](50) NOT NULL,
	[show] [bit] NOT NULL CONSTRAINT [DF_patentes_show]  DEFAULT ((0)),
 CONSTRAINT [PK_patentes] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[proposals]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[proposals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[amount] [money] NOT NULL,
	[description] [varchar](150) NOT NULL,
	[resource_id] [int] NOT NULL,
	[employer_id] [int] NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_proposals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Confluence_Diff_Backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[Confluence_Diff_Backup]
AS
BEGIN
	BACKUP DATABASE Confluence TO DISK = N''c:\confluence.bak'' WITH DIFFERENTIAL
END


' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[scheduled_backups]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[scheduled_backups](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[done] [int] NOT NULL,
 CONSTRAINT [PK_scheduled_backups] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[scheduled_backup]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[scheduled_backup] AS
BEGIN
	BACKUP DATABASE Confluence TO DISK = N''c:\confluence_scheduled.bak''
END
' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[projectstates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[projectstates](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_projectstates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[publications]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[publications](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_publication] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[questionstates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[questionstates](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_questionstates] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[access_log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[access_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[time] [datetime] NOT NULL,
	[action] [varchar](50) NOT NULL,
 CONSTRAINT [PK_access_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[operation_log]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[operation_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[user_name] [varchar](50) NOT NULL,
	[operation] [varchar](80) NOT NULL,
	[time] [datetime] NOT NULL,
 CONSTRAINT [PK_operation_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[offers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[offers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[bidder_id] [int] NOT NULL,
	[amount] [money] NOT NULL,
	[release_date] [datetime] NOT NULL,
	[counter_offer] [int] NULL,
	[project_id] [int] NOT NULL,
	[DVH] [bigint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[answers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[answers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[text] [varchar](100) NOT NULL,
	[DVH] [bigint] NULL,
 CONSTRAINT [PK_answers] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[languages]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[languages](
	[id] [int] NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_languages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[servicetypes]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[servicetypes](
	[id] [int] NOT NULL,
	[description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_servicetype] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoKillFams]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NoKillFams](
	[id] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoKillUsers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NoKillUsers](
	[id] [int] NOT NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NoKillPats]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[NoKillPats](
	[id] [int] NOT NULL
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__NoKillFams__id__30C33EC3]') AND parent_object_id = OBJECT_ID(N'[dbo].[NoKillFams]'))
ALTER TABLE [dbo].[NoKillFams]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [dbo].[families] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__NoKillUsers__id__395884C4]') AND parent_object_id = OBJECT_ID(N'[dbo].[NoKillUsers]'))
ALTER TABLE [dbo].[NoKillUsers]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [dbo].[users] ([id])
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK__NoKillPats__id__3493CFA7]') AND parent_object_id = OBJECT_ID(N'[dbo].[NoKillPats]'))
ALTER TABLE [dbo].[NoKillPats]  WITH CHECK ADD FOREIGN KEY([id])
REFERENCES [dbo].[patentes] ([id])
