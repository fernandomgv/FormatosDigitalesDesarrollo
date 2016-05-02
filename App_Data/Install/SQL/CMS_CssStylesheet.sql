CREATE TABLE [CMS_CssStylesheet] (
		[StylesheetID]                        [int] IDENTITY(1, 1) NOT NULL,
		[StylesheetDisplayName]               [nvarchar](200) NOT NULL,
		[StylesheetName]                      [nvarchar](200) NOT NULL,
		[StylesheetText]                      [nvarchar](max) NOT NULL,
		[StylesheetCheckedOutByUserID]        [int] NULL,
		[StylesheetCheckedOutMachineName]     [nvarchar](100) NULL,
		[StylesheetCheckedOutFileName]        [nvarchar](450) NULL,
		[StylesheetVersionGUID]               [nvarchar](50) NULL,
		[StylesheetGUID]                      [uniqueidentifier] NOT NULL,
		[StylesheetLastModified]              [datetime] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [CMS_CssStylesheet]
	ADD
	CONSTRAINT [PK_CMS_CssStylesheet]
	PRIMARY KEY
	NONCLUSTERED
	([StylesheetID])
	WITH FILLFACTOR=80
	ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_CMS_CssStylesheet_StylesheetCheckedOutByUserID]
	ON [CMS_CssStylesheet] ([StylesheetCheckedOutByUserID])
	ON [PRIMARY]
CREATE CLUSTERED INDEX [IX_CMS_CssStylesheet_StylesheetDisplayName]
	ON [CMS_CssStylesheet] ([StylesheetDisplayName])
	WITH ( FILLFACTOR = 80)
	ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_CMS_CssStylesheet_StylesheetName]
	ON [CMS_CssStylesheet] ([StylesheetName])
	WITH ( FILLFACTOR = 80)
	ON [PRIMARY]
ALTER TABLE [CMS_CssStylesheet]
	WITH CHECK
	ADD CONSTRAINT [FK_CMS_CssStylesheet_StylesheetCheckedOutByUserID_CMS_User]
	FOREIGN KEY ([StylesheetCheckedOutByUserID]) REFERENCES [CMS_User] ([UserID])
ALTER TABLE [CMS_CssStylesheet]
	CHECK CONSTRAINT [FK_CMS_CssStylesheet_StylesheetCheckedOutByUserID_CMS_User]
