CREATE TABLE [CMS_RelationshipName] (
		[RelationshipNameID]             [int] IDENTITY(1, 1) NOT NULL,
		[RelationshipDisplayName]        [nvarchar](200) NOT NULL,
		[RelationshipName]               [nvarchar](200) NOT NULL,
		[RelationshipAllowedObjects]     [nvarchar](450) NULL,
		[RelationshipGUID]               [uniqueidentifier] NOT NULL,
		[RelationshipLastModified]       [datetime] NOT NULL
) ON [PRIMARY]
ALTER TABLE [CMS_RelationshipName]
	ADD
	CONSTRAINT [PK_CMS_RelationshipName]
	PRIMARY KEY
	CLUSTERED
	([RelationshipNameID])
	WITH FILLFACTOR=80
	ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_CMS_RelationshipName_RelationshipAllowedObjects]
	ON [CMS_RelationshipName] ([RelationshipAllowedObjects])
	WITH ( FILLFACTOR = 80)
	ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_CMS_RelationshipName_RelationshipName_RelationshipDisplayName]
	ON [CMS_RelationshipName] ([RelationshipName], [RelationshipDisplayName])
	WITH ( FILLFACTOR = 80)
	ON [PRIMARY]
