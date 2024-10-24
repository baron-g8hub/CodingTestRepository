CREATE TABLE [dbo].[CompanyProfile]
(
	CompanyId INT NOT NULL PRIMARY KEY IDENTITY,
     CompanyName   NVARCHAR (50) NULL,
	 [IsActive]    BIT           DEFAULT ((0)) NULL,
    [CreatedDate] DATETIME      DEFAULT (getutcdate()) NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [UpdatedDate] DATETIME      DEFAULT (getutcdate()) NULL,
    [UpdatedBy]   NVARCHAR (50) NULL,
)
