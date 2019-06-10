CREATE PROCEDURE [GetAllItemTypes]
                    
                AS
                BEGIN
                    SET NOCOUNT ON;
                    SELECT ItemTypeID, Item FROM ItemTypes
                END