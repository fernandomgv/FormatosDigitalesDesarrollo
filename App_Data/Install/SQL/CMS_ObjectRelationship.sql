CREATE TABLE [CMS_ObjectRelationship] (
		[RelationshipLeftObjectID]        [int] NOT NULL,
		[RelationshipLeftObjectType]      [nvarchar](100) NOT NULL,
		[RelationshipNameID]              [int] NOT NULL,
		[RelationshipRightObjectID]       [int] NOT NULL,
		[RelationshipRightObjectType]     [nvarchar](100) NOT NULL,
		[RelationshipCustomData]          [nvarchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
ALTER TABLE [CMS_ObjectRelationship]
	ADD
	CONSTRAINT [PK_CMS_ObjectRelationship]
	PRIMARY KEY
	CLUSTERED
	([RelationshipLeftObjectID], [RelationshipLeftObjectType], [RelationshipNameID], [RelationshipRightObjectID], [RelationshipRightObjectType])
	WITH FILLFACTOR=80
	ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_CMS_ObjectRelationship_RelationshipLeftObjectType_RelationshipLeftObjectID]
	ON [CMS_ObjectRelationship] ([RelationshipLeftObjectType], [RelationshipLeftObjectID])
	WITH ( FILLFACTOR = 80)
	ON [PRIMARY]
CREATE NONCLUSTERED INDEX [IX_CMS_ObjectRelationship_RelationshipRightObjectType_RelationshipRightObjectID]
	ON [CMS_ObjectRelationship] ([RelationshipRightObjectType], [RelationshipRightObjectID])
	WITH ( FILLFACTOR = 80)
	ON [PRIMARY]
ALTER TABLE [CMS_ObjectRelationship]
	WITH CHECK
	ADD CONSTRAINT [FK_CMS_ObjectRelationship_RelationshipNameID_CMS_RelationshipName]
	FOREIGN KEY ([RelationshipNameID]) REFERENCES [CMS_RelationshipName] ([RelationshipNameID])
ALTER TABLE [CMS_ObjectRelationship]
	CHECK CONSTRAINT [FK_CMS_ObjectRelationship_RelationshipNameID_CMS_RelationshipName]
