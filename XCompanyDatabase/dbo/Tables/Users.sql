CREATE TABLE [dbo].[Users] (
    [Id]          INT           NOT NULL,
    [Username]    NVARCHAR (50) NULL,
    [CompanyId]   INT           NULL,
    [UserTypeId]  INT           NULL,
    [IsActive]    BIT           DEFAULT ((0)) NULL,
    [CreatedDate] DATETIME      DEFAULT (getutcdate()) NULL,
    [CreatedBy]   NVARCHAR (50) NULL,
    [UpdatedDate] DATETIME      DEFAULT (getutcdate()) NULL,
    [UpdatedBy]   NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

