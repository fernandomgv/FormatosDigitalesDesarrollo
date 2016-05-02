CREATE PROCEDURE [Proc_CMS_ACL_ClearACLs]
	@NodeID int, @NewACLID int
AS
BEGIN
	UPDATE CMS_Tree SET NodeACLID = @NewACLID WHERE NodeID=@NodeID
	DELETE FROM CMS_ACLItem WHERE ACLID IN (SELECT CMS_ACL.ACLID FROM CMS_ACL LEFT JOIN CMS_Tree ON CMS_Tree.NodeID = CMS_ACL.ACLOwnerNodeID WHERE (CMS_Tree.NodeID IS NULL) OR (CMS_Tree.NodeID IS NOT NULL AND CMS_Tree.NodeACLID <> CMS_ACL.ACLID))
	DELETE FROM CMS_ACL WHERE ACLID IN (SELECT CMS_ACL.ACLID FROM CMS_ACL LEFT JOIN CMS_Tree ON CMS_Tree.NodeID = CMS_ACL.ACLOwnerNodeID WHERE (CMS_Tree.NodeID IS NULL) OR (CMS_Tree.NodeID IS NOT NULL AND CMS_Tree.NodeACLID <> CMS_ACL.ACLID))
END
