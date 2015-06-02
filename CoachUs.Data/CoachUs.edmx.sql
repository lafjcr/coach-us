
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2015 22:00:23
-- Generated from EDMX file: D:\Source\GitHub\coach-us\CoachUs.Data\CoachUs.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [coachus];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Action_ParentAction]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Actions] DROP CONSTRAINT [FK_Action_ParentAction];
GO
IF OBJECT_ID(N'[dbo].[FK_Activity_Training]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activities] DROP CONSTRAINT [FK_Activity_Training];
GO
IF OBJECT_ID(N'[dbo].[FK_ActivityCategory_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Activities] DROP CONSTRAINT [FK_ActivityCategory_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_AthletePlan_Athlete]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AthletePlans] DROP CONSTRAINT [FK_AthletePlan_Athlete];
GO
IF OBJECT_ID(N'[dbo].[FK_AthletePlan_Coach]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AthletePlans] DROP CONSTRAINT [FK_AthletePlan_Coach];
GO
IF OBJECT_ID(N'[dbo].[FK_AthletePlan_Plan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AthletePlans] DROP CONSTRAINT [FK_AthletePlan_Plan];
GO
IF OBJECT_ID(N'[dbo].[FK_AthletePlan_SharedByUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AthletePlans] DROP CONSTRAINT [FK_AthletePlan_SharedByUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CoachPlan_Coach]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamPlans] DROP CONSTRAINT [FK_CoachPlan_Coach];
GO
IF OBJECT_ID(N'[dbo].[FK_Event_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Events] DROP CONSTRAINT [FK_Event_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_EventGallery_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventGallery] DROP CONSTRAINT [FK_EventGallery_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventGallery_File]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventGallery] DROP CONSTRAINT [FK_EventGallery_File];
GO
IF OBJECT_ID(N'[dbo].[FK_EventTraining_Event]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventTrainings] DROP CONSTRAINT [FK_EventTraining_Event];
GO
IF OBJECT_ID(N'[dbo].[FK_EventTraining_Training]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EventTrainings] DROP CONSTRAINT [FK_EventTraining_Training];
GO
IF OBJECT_ID(N'[dbo].[FK_Fare_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Fares] DROP CONSTRAINT [FK_Fare_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_Inventory_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Inventories] DROP CONSTRAINT [FK_Inventory_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_License_Owner]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Licenses] DROP CONSTRAINT [FK_License_Owner];
GO
IF OBJECT_ID(N'[dbo].[FK_LicensePayments_License]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LicensePayments] DROP CONSTRAINT [FK_LicensePayments_License];
GO
IF OBJECT_ID(N'[dbo].[FK_ParentActivityCategory_ActivityCategory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivityCategories] DROP CONSTRAINT [FK_ParentActivityCategory_ActivityCategory];
GO
IF OBJECT_ID(N'[dbo].[FK_Permission_Action]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissions] DROP CONSTRAINT [FK_Permission_Action];
GO
IF OBJECT_ID(N'[dbo].[FK_Permission_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Permissions] DROP CONSTRAINT [FK_Permission_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_Plan_Author]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plans] DROP CONSTRAINT [FK_Plan_Author];
GO
IF OBJECT_ID(N'[dbo].[FK_Plan_LastModifier]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Plans] DROP CONSTRAINT [FK_Plan_LastModifier];
GO
IF OBJECT_ID(N'[dbo].[FK_Result_Activity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ActivityResults] DROP CONSTRAINT [FK_Result_Activity];
GO
IF OBJECT_ID(N'[dbo].[FK_Sale_Buyer]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_Sale_Buyer];
GO
IF OBJECT_ID(N'[dbo].[FK_Sale_Inventory]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_Sale_Inventory];
GO
IF OBJECT_ID(N'[dbo].[FK_Sale_Seller]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Sales] DROP CONSTRAINT [FK_Sale_Seller];
GO
IF OBJECT_ID(N'[dbo].[FK_Subscription_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subscriptions] DROP CONSTRAINT [FK_Subscription_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_Subscription_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subscriptions] DROP CONSTRAINT [FK_Subscription_User];
GO
IF OBJECT_ID(N'[dbo].[FK_SubscriptionPayment_Subscription]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SubscriptionPayments] DROP CONSTRAINT [FK_SubscriptionPayment_Subscription];
GO
IF OBJECT_ID(N'[dbo].[FK_Team_Logo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_Team_Logo];
GO
IF OBJECT_ID(N'[dbo].[FK_Team_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Teams] DROP CONSTRAINT [FK_Team_User];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPlan_Plan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamPlans] DROP CONSTRAINT [FK_TeamPlan_Plan];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPlan_SharedByUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamPlans] DROP CONSTRAINT [FK_TeamPlan_SharedByUser];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamPlan_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamPlans] DROP CONSTRAINT [FK_TeamPlan_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamUser_Role]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamUsers] DROP CONSTRAINT [FK_TeamUser_Role];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamUser_Team]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamUsers] DROP CONSTRAINT [FK_TeamUser_Team];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamUser_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamUsers] DROP CONSTRAINT [FK_TeamUser_User];
GO
IF OBJECT_ID(N'[dbo].[FK_Training_Plan]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Trainings] DROP CONSTRAINT [FK_Training_Plan];
GO
IF OBJECT_ID(N'[dbo].[FK_User_Picture]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_User_Picture];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Actions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Actions];
GO
IF OBJECT_ID(N'[dbo].[Activities]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Activities];
GO
IF OBJECT_ID(N'[dbo].[ActivityCategories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivityCategories];
GO
IF OBJECT_ID(N'[dbo].[ActivityResults]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ActivityResults];
GO
IF OBJECT_ID(N'[dbo].[AthletePlans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AthletePlans];
GO
IF OBJECT_ID(N'[dbo].[EventGallery]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventGallery];
GO
IF OBJECT_ID(N'[dbo].[Events]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Events];
GO
IF OBJECT_ID(N'[dbo].[EventTrainings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EventTrainings];
GO
IF OBJECT_ID(N'[dbo].[Fares]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Fares];
GO
IF OBJECT_ID(N'[dbo].[Files]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Files];
GO
IF OBJECT_ID(N'[dbo].[Inventories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Inventories];
GO
IF OBJECT_ID(N'[dbo].[LicensePayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LicensePayments];
GO
IF OBJECT_ID(N'[dbo].[Licenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Licenses];
GO
IF OBJECT_ID(N'[dbo].[Permissions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Permissions];
GO
IF OBJECT_ID(N'[dbo].[Plans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Plans];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[Sales]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Sales];
GO
IF OBJECT_ID(N'[dbo].[SubscriptionPayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SubscriptionPayments];
GO
IF OBJECT_ID(N'[dbo].[Subscriptions]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subscriptions];
GO
IF OBJECT_ID(N'[dbo].[TeamPlans]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamPlans];
GO
IF OBJECT_ID(N'[dbo].[Teams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teams];
GO
IF OBJECT_ID(N'[dbo].[TeamUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamUsers];
GO
IF OBJECT_ID(N'[dbo].[Trainings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Trainings];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Actions'
CREATE TABLE [dbo].[Actions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ParentActionID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Type] tinyint  NOT NULL
);
GO

-- Creating table 'Activities'
CREATE TABLE [dbo].[Activities] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TrainingID] int  NOT NULL,
    [ActivityCategoryID] int  NOT NULL,
    [Order] tinyint  NOT NULL,
    [Series] tinyint  NOT NULL,
    [Repetitions] decimal(18,0)  NOT NULL,
    [Unit] tinyint  NOT NULL,
    [Goal] decimal(9,2)  NOT NULL,
    [GoalUnit] tinyint  NOT NULL,
    [Notes] nvarchar(200)  NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'ActivityCategories'
CREATE TABLE [dbo].[ActivityCategories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [ParentActivityCategoryID] int  NOT NULL
);
GO

-- Creating table 'ActivityResults'
CREATE TABLE [dbo].[ActivityResults] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [ActivityID] int  NOT NULL,
    [Serie] tinyint  NOT NULL,
    [Repetition] decimal(18,0)  NOT NULL,
    [Result] decimal(9,2)  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'AthletePlans'
CREATE TABLE [dbo].[AthletePlans] (
    [PlanID] int  NOT NULL,
    [AthleteID] int  NOT NULL,
    [CoachID] int  NOT NULL,
    [SharedByUser] int  NOT NULL
);
GO

-- Creating table 'Events'
CREATE TABLE [dbo].[Events] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TeamID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Title] nvarchar(75)  NOT NULL,
    [Detail] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'EventTrainings'
CREATE TABLE [dbo].[EventTrainings] (
    [EventID] int  NOT NULL,
    [TrainingID] int  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Fares'
CREATE TABLE [dbo].[Fares] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TeamID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [CreatedDate] datetime  NOT NULL
);
GO

-- Creating table 'Files'
CREATE TABLE [dbo].[Files] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Path] nvarchar(255)  NOT NULL,
    [Thumbnail] nvarchar(255)  NULL
);
GO

-- Creating table 'Inventories'
CREATE TABLE [dbo].[Inventories] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [TeamID] int  NOT NULL,
    [Item] nvarchar(50)  NOT NULL,
    [Description] nvarchar(200)  NOT NULL,
    [Qty] int  NOT NULL,
    [Price] decimal(10,4)  NOT NULL,
    [AllowCouchSell] bit  NOT NULL,
    [AllowCouchChangePrice] bit  NOT NULL
);
GO

-- Creating table 'LicensePayments'
CREATE TABLE [dbo].[LicensePayments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [LicenseID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Users] smallint  NOT NULL,
    [Days] smallint  NOT NULL,
    [Amount] decimal(10,4)  NOT NULL,
    [IsPaid] bit  NOT NULL
);
GO

-- Creating table 'Licenses'
CREATE TABLE [dbo].[Licenses] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [OwnerID] int  NOT NULL,
    [CreatedDate] datetime  NOT NULL,
    [TrialDays] smallint  NOT NULL,
    [Days] smallint  NOT NULL,
    [TotalUsers] smallint  NOT NULL,
    [AvailableUsers] smallint  NOT NULL
);
GO

-- Creating table 'Permissions'
CREATE TABLE [dbo].[Permissions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [RoleID] int  NOT NULL,
    [AccessType] tinyint  NOT NULL,
    [ActionID] int  NOT NULL
);
GO

-- Creating table 'Plans'
CREATE TABLE [dbo].[Plans] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AuthorID] int  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [IsTemplate] bit  NOT NULL,
    [StartDate] datetime  NULL,
    [EndDate] datetime  NULL,
    [LastModifierID] int  NOT NULL,
    [LastModifyDate] datetime  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NOT NULL
);
GO

-- Creating table 'Sales'
CREATE TABLE [dbo].[Sales] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SellerID] int  NOT NULL,
    [BuyerID] int  NOT NULL,
    [ItemID] int  NOT NULL,
    [Price] decimal(10,4)  NOT NULL,
    [Date] datetime  NOT NULL,
    [PaidDate] datetime  NULL
);
GO

-- Creating table 'SubscriptionPayments'
CREATE TABLE [dbo].[SubscriptionPayments] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [SubscriptionID] int  NOT NULL,
    [Amount] int  NOT NULL,
    [Date] datetime  NOT NULL
);
GO

-- Creating table 'Subscriptions'
CREATE TABLE [dbo].[Subscriptions] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [AthleteID] int  NOT NULL,
    [TeamID] int  NOT NULL,
    [StartDate] datetime  NOT NULL,
    [EndDate] datetime  NULL,
    [MonthlyFee] decimal(10,4)  NOT NULL,
    [PaymentDay] tinyint  NOT NULL
);
GO

-- Creating table 'TeamPlans'
CREATE TABLE [dbo].[TeamPlans] (
    [PlanID] int  NOT NULL,
    [TeamID] int  NOT NULL,
    [CoachID] int  NOT NULL,
    [SharedByUser] int  NOT NULL
);
GO

-- Creating table 'Teams'
CREATE TABLE [dbo].[Teams] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Name] nchar(10)  NOT NULL,
    [Sport] tinyint  NOT NULL,
    [Email] nvarchar(75)  NOT NULL,
    [TeamOwnerID] int  NOT NULL,
    [LogoID] int  NULL
);
GO

-- Creating table 'TeamUsers'
CREATE TABLE [dbo].[TeamUsers] (
    [TeamID] int  NOT NULL,
    [UserID] int  NOT NULL,
    [RoleID] int  NOT NULL
);
GO

-- Creating table 'Trainings'
CREATE TABLE [dbo].[Trainings] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [PlanID] int  NOT NULL,
    [Date] datetime  NOT NULL,
    [Category] tinyint  NOT NULL,
    [Status] tinyint  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [ID] int IDENTITY(1,1) NOT NULL,
    [Email] nvarchar(75)  NOT NULL,
    [Password] nvarchar(25)  NOT NULL,
    [Name] nvarchar(50)  NOT NULL,
    [LastName] nvarchar(50)  NOT NULL,
    [BirthDate] datetime  NOT NULL,
    [Gender] nvarchar(1)  NOT NULL,
    [Laterality] nvarchar(1)  NOT NULL,
    [Country] nvarchar(50)  NOT NULL,
    [Address] nvarchar(100)  NULL,
    [PictureID] int  NULL
);
GO

-- Creating table 'EventGallery'
CREATE TABLE [dbo].[EventGallery] (
    [Events_ID] int  NOT NULL,
    [Files_ID] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ID] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [PK_Actions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [PK_Activities]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActivityCategories'
ALTER TABLE [dbo].[ActivityCategories]
ADD CONSTRAINT [PK_ActivityCategories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'ActivityResults'
ALTER TABLE [dbo].[ActivityResults]
ADD CONSTRAINT [PK_ActivityResults]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PlanID], [AthleteID] in table 'AthletePlans'
ALTER TABLE [dbo].[AthletePlans]
ADD CONSTRAINT [PK_AthletePlans]
    PRIMARY KEY CLUSTERED ([PlanID], [AthleteID] ASC);
GO

-- Creating primary key on [ID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [PK_Events]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [EventID], [TrainingID] in table 'EventTrainings'
ALTER TABLE [dbo].[EventTrainings]
ADD CONSTRAINT [PK_EventTrainings]
    PRIMARY KEY CLUSTERED ([EventID], [TrainingID] ASC);
GO

-- Creating primary key on [ID] in table 'Fares'
ALTER TABLE [dbo].[Fares]
ADD CONSTRAINT [PK_Fares]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Files'
ALTER TABLE [dbo].[Files]
ADD CONSTRAINT [PK_Files]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [PK_Inventories]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'LicensePayments'
ALTER TABLE [dbo].[LicensePayments]
ADD CONSTRAINT [PK_LicensePayments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [PK_Licenses]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [PK_Permissions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Plans'
ALTER TABLE [dbo].[Plans]
ADD CONSTRAINT [PK_Plans]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [PK_Sales]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'SubscriptionPayments'
ALTER TABLE [dbo].[SubscriptionPayments]
ADD CONSTRAINT [PK_SubscriptionPayments]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [PK_Subscriptions]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [PlanID], [TeamID] in table 'TeamPlans'
ALTER TABLE [dbo].[TeamPlans]
ADD CONSTRAINT [PK_TeamPlans]
    PRIMARY KEY CLUSTERED ([PlanID], [TeamID] ASC);
GO

-- Creating primary key on [ID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [PK_Teams]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [TeamID], [UserID] in table 'TeamUsers'
ALTER TABLE [dbo].[TeamUsers]
ADD CONSTRAINT [PK_TeamUsers]
    PRIMARY KEY CLUSTERED ([TeamID], [UserID] ASC);
GO

-- Creating primary key on [ID] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [PK_Trainings]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [ID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([ID] ASC);
GO

-- Creating primary key on [Events_ID], [Files_ID] in table 'EventGallery'
ALTER TABLE [dbo].[EventGallery]
ADD CONSTRAINT [PK_EventGallery]
    PRIMARY KEY CLUSTERED ([Events_ID], [Files_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ParentActionID] in table 'Actions'
ALTER TABLE [dbo].[Actions]
ADD CONSTRAINT [FK_Action_ParentAction]
    FOREIGN KEY ([ParentActionID])
    REFERENCES [dbo].[Actions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Action_ParentAction'
CREATE INDEX [IX_FK_Action_ParentAction]
ON [dbo].[Actions]
    ([ParentActionID]);
GO

-- Creating foreign key on [ActionID] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [FK_Permission_Action]
    FOREIGN KEY ([ActionID])
    REFERENCES [dbo].[Actions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Permission_Action'
CREATE INDEX [IX_FK_Permission_Action]
ON [dbo].[Permissions]
    ([ActionID]);
GO

-- Creating foreign key on [TrainingID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [FK_Activity_Training]
    FOREIGN KEY ([TrainingID])
    REFERENCES [dbo].[Trainings]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Activity_Training'
CREATE INDEX [IX_FK_Activity_Training]
ON [dbo].[Activities]
    ([TrainingID]);
GO

-- Creating foreign key on [ActivityCategoryID] in table 'Activities'
ALTER TABLE [dbo].[Activities]
ADD CONSTRAINT [FK_ActivityCategory_Activity]
    FOREIGN KEY ([ActivityCategoryID])
    REFERENCES [dbo].[ActivityCategories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ActivityCategory_Activity'
CREATE INDEX [IX_FK_ActivityCategory_Activity]
ON [dbo].[Activities]
    ([ActivityCategoryID]);
GO

-- Creating foreign key on [ActivityID] in table 'ActivityResults'
ALTER TABLE [dbo].[ActivityResults]
ADD CONSTRAINT [FK_Result_Activity]
    FOREIGN KEY ([ActivityID])
    REFERENCES [dbo].[Activities]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Result_Activity'
CREATE INDEX [IX_FK_Result_Activity]
ON [dbo].[ActivityResults]
    ([ActivityID]);
GO

-- Creating foreign key on [ParentActivityCategoryID] in table 'ActivityCategories'
ALTER TABLE [dbo].[ActivityCategories]
ADD CONSTRAINT [FK_ParentActivityCategory_ActivityCategory]
    FOREIGN KEY ([ParentActivityCategoryID])
    REFERENCES [dbo].[ActivityCategories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ParentActivityCategory_ActivityCategory'
CREATE INDEX [IX_FK_ParentActivityCategory_ActivityCategory]
ON [dbo].[ActivityCategories]
    ([ParentActivityCategoryID]);
GO

-- Creating foreign key on [AthleteID] in table 'AthletePlans'
ALTER TABLE [dbo].[AthletePlans]
ADD CONSTRAINT [FK_AthletePlan_Athlete]
    FOREIGN KEY ([AthleteID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AthletePlan_Athlete'
CREATE INDEX [IX_FK_AthletePlan_Athlete]
ON [dbo].[AthletePlans]
    ([AthleteID]);
GO

-- Creating foreign key on [CoachID] in table 'AthletePlans'
ALTER TABLE [dbo].[AthletePlans]
ADD CONSTRAINT [FK_AthletePlan_Coach]
    FOREIGN KEY ([CoachID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AthletePlan_Coach'
CREATE INDEX [IX_FK_AthletePlan_Coach]
ON [dbo].[AthletePlans]
    ([CoachID]);
GO

-- Creating foreign key on [PlanID] in table 'AthletePlans'
ALTER TABLE [dbo].[AthletePlans]
ADD CONSTRAINT [FK_AthletePlan_Plan]
    FOREIGN KEY ([PlanID])
    REFERENCES [dbo].[Plans]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [SharedByUser] in table 'AthletePlans'
ALTER TABLE [dbo].[AthletePlans]
ADD CONSTRAINT [FK_AthletePlan_SharedByUser]
    FOREIGN KEY ([SharedByUser])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AthletePlan_SharedByUser'
CREATE INDEX [IX_FK_AthletePlan_SharedByUser]
ON [dbo].[AthletePlans]
    ([SharedByUser]);
GO

-- Creating foreign key on [TeamID] in table 'Events'
ALTER TABLE [dbo].[Events]
ADD CONSTRAINT [FK_Event_Team]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Event_Team'
CREATE INDEX [IX_FK_Event_Team]
ON [dbo].[Events]
    ([TeamID]);
GO

-- Creating foreign key on [EventID] in table 'EventTrainings'
ALTER TABLE [dbo].[EventTrainings]
ADD CONSTRAINT [FK_EventTraining_Event]
    FOREIGN KEY ([EventID])
    REFERENCES [dbo].[Events]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TrainingID] in table 'EventTrainings'
ALTER TABLE [dbo].[EventTrainings]
ADD CONSTRAINT [FK_EventTraining_Training]
    FOREIGN KEY ([TrainingID])
    REFERENCES [dbo].[Trainings]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventTraining_Training'
CREATE INDEX [IX_FK_EventTraining_Training]
ON [dbo].[EventTrainings]
    ([TrainingID]);
GO

-- Creating foreign key on [TeamID] in table 'Fares'
ALTER TABLE [dbo].[Fares]
ADD CONSTRAINT [FK_Fare_Team]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Fare_Team'
CREATE INDEX [IX_FK_Fare_Team]
ON [dbo].[Fares]
    ([TeamID]);
GO

-- Creating foreign key on [LogoID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_Team_Logo]
    FOREIGN KEY ([LogoID])
    REFERENCES [dbo].[Files]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Team_Logo'
CREATE INDEX [IX_FK_Team_Logo]
ON [dbo].[Teams]
    ([LogoID]);
GO

-- Creating foreign key on [PictureID] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_User_Picture]
    FOREIGN KEY ([PictureID])
    REFERENCES [dbo].[Files]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_User_Picture'
CREATE INDEX [IX_FK_User_Picture]
ON [dbo].[Users]
    ([PictureID]);
GO

-- Creating foreign key on [TeamID] in table 'Inventories'
ALTER TABLE [dbo].[Inventories]
ADD CONSTRAINT [FK_Inventory_Team]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Inventory_Team'
CREATE INDEX [IX_FK_Inventory_Team]
ON [dbo].[Inventories]
    ([TeamID]);
GO

-- Creating foreign key on [ItemID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_Sale_Inventory]
    FOREIGN KEY ([ItemID])
    REFERENCES [dbo].[Inventories]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sale_Inventory'
CREATE INDEX [IX_FK_Sale_Inventory]
ON [dbo].[Sales]
    ([ItemID]);
GO

-- Creating foreign key on [LicenseID] in table 'LicensePayments'
ALTER TABLE [dbo].[LicensePayments]
ADD CONSTRAINT [FK_LicensePayments_License]
    FOREIGN KEY ([LicenseID])
    REFERENCES [dbo].[Licenses]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LicensePayments_License'
CREATE INDEX [IX_FK_LicensePayments_License]
ON [dbo].[LicensePayments]
    ([LicenseID]);
GO

-- Creating foreign key on [OwnerID] in table 'Licenses'
ALTER TABLE [dbo].[Licenses]
ADD CONSTRAINT [FK_License_Owner]
    FOREIGN KEY ([OwnerID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_License_Owner'
CREATE INDEX [IX_FK_License_Owner]
ON [dbo].[Licenses]
    ([OwnerID]);
GO

-- Creating foreign key on [RoleID] in table 'Permissions'
ALTER TABLE [dbo].[Permissions]
ADD CONSTRAINT [FK_Permission_Role]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Permission_Role'
CREATE INDEX [IX_FK_Permission_Role]
ON [dbo].[Permissions]
    ([RoleID]);
GO

-- Creating foreign key on [AuthorID] in table 'Plans'
ALTER TABLE [dbo].[Plans]
ADD CONSTRAINT [FK_Plan_Author]
    FOREIGN KEY ([AuthorID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Plan_Author'
CREATE INDEX [IX_FK_Plan_Author]
ON [dbo].[Plans]
    ([AuthorID]);
GO

-- Creating foreign key on [LastModifierID] in table 'Plans'
ALTER TABLE [dbo].[Plans]
ADD CONSTRAINT [FK_Plan_LastModifier]
    FOREIGN KEY ([LastModifierID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Plan_LastModifier'
CREATE INDEX [IX_FK_Plan_LastModifier]
ON [dbo].[Plans]
    ([LastModifierID]);
GO

-- Creating foreign key on [PlanID] in table 'TeamPlans'
ALTER TABLE [dbo].[TeamPlans]
ADD CONSTRAINT [FK_TeamPlan_Plan]
    FOREIGN KEY ([PlanID])
    REFERENCES [dbo].[Plans]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [PlanID] in table 'Trainings'
ALTER TABLE [dbo].[Trainings]
ADD CONSTRAINT [FK_Training_Plan]
    FOREIGN KEY ([PlanID])
    REFERENCES [dbo].[Plans]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Training_Plan'
CREATE INDEX [IX_FK_Training_Plan]
ON [dbo].[Trainings]
    ([PlanID]);
GO

-- Creating foreign key on [RoleID] in table 'TeamUsers'
ALTER TABLE [dbo].[TeamUsers]
ADD CONSTRAINT [FK_TeamUser_Role]
    FOREIGN KEY ([RoleID])
    REFERENCES [dbo].[Roles]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamUser_Role'
CREATE INDEX [IX_FK_TeamUser_Role]
ON [dbo].[TeamUsers]
    ([RoleID]);
GO

-- Creating foreign key on [BuyerID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_Sale_Buyer]
    FOREIGN KEY ([BuyerID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sale_Buyer'
CREATE INDEX [IX_FK_Sale_Buyer]
ON [dbo].[Sales]
    ([BuyerID]);
GO

-- Creating foreign key on [SellerID] in table 'Sales'
ALTER TABLE [dbo].[Sales]
ADD CONSTRAINT [FK_Sale_Seller]
    FOREIGN KEY ([SellerID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Sale_Seller'
CREATE INDEX [IX_FK_Sale_Seller]
ON [dbo].[Sales]
    ([SellerID]);
GO

-- Creating foreign key on [SubscriptionID] in table 'SubscriptionPayments'
ALTER TABLE [dbo].[SubscriptionPayments]
ADD CONSTRAINT [FK_SubscriptionPayment_Subscription]
    FOREIGN KEY ([SubscriptionID])
    REFERENCES [dbo].[Subscriptions]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SubscriptionPayment_Subscription'
CREATE INDEX [IX_FK_SubscriptionPayment_Subscription]
ON [dbo].[SubscriptionPayments]
    ([SubscriptionID]);
GO

-- Creating foreign key on [TeamID] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [FK_Subscription_Team]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subscription_Team'
CREATE INDEX [IX_FK_Subscription_Team]
ON [dbo].[Subscriptions]
    ([TeamID]);
GO

-- Creating foreign key on [AthleteID] in table 'Subscriptions'
ALTER TABLE [dbo].[Subscriptions]
ADD CONSTRAINT [FK_Subscription_User]
    FOREIGN KEY ([AthleteID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subscription_User'
CREATE INDEX [IX_FK_Subscription_User]
ON [dbo].[Subscriptions]
    ([AthleteID]);
GO

-- Creating foreign key on [CoachID] in table 'TeamPlans'
ALTER TABLE [dbo].[TeamPlans]
ADD CONSTRAINT [FK_CoachPlan_Coach]
    FOREIGN KEY ([CoachID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CoachPlan_Coach'
CREATE INDEX [IX_FK_CoachPlan_Coach]
ON [dbo].[TeamPlans]
    ([CoachID]);
GO

-- Creating foreign key on [SharedByUser] in table 'TeamPlans'
ALTER TABLE [dbo].[TeamPlans]
ADD CONSTRAINT [FK_TeamPlan_SharedByUser]
    FOREIGN KEY ([SharedByUser])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlan_SharedByUser'
CREATE INDEX [IX_FK_TeamPlan_SharedByUser]
ON [dbo].[TeamPlans]
    ([SharedByUser]);
GO

-- Creating foreign key on [TeamID] in table 'TeamPlans'
ALTER TABLE [dbo].[TeamPlans]
ADD CONSTRAINT [FK_TeamPlan_Team]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamPlan_Team'
CREATE INDEX [IX_FK_TeamPlan_Team]
ON [dbo].[TeamPlans]
    ([TeamID]);
GO

-- Creating foreign key on [TeamOwnerID] in table 'Teams'
ALTER TABLE [dbo].[Teams]
ADD CONSTRAINT [FK_Team_User]
    FOREIGN KEY ([TeamOwnerID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Team_User'
CREATE INDEX [IX_FK_Team_User]
ON [dbo].[Teams]
    ([TeamOwnerID]);
GO

-- Creating foreign key on [TeamID] in table 'TeamUsers'
ALTER TABLE [dbo].[TeamUsers]
ADD CONSTRAINT [FK_TeamUser_Team]
    FOREIGN KEY ([TeamID])
    REFERENCES [dbo].[Teams]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [UserID] in table 'TeamUsers'
ALTER TABLE [dbo].[TeamUsers]
ADD CONSTRAINT [FK_TeamUser_User]
    FOREIGN KEY ([UserID])
    REFERENCES [dbo].[Users]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamUser_User'
CREATE INDEX [IX_FK_TeamUser_User]
ON [dbo].[TeamUsers]
    ([UserID]);
GO

-- Creating foreign key on [Events_ID] in table 'EventGallery'
ALTER TABLE [dbo].[EventGallery]
ADD CONSTRAINT [FK_EventGallery_Events]
    FOREIGN KEY ([Events_ID])
    REFERENCES [dbo].[Events]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Files_ID] in table 'EventGallery'
ALTER TABLE [dbo].[EventGallery]
ADD CONSTRAINT [FK_EventGallery_Files]
    FOREIGN KEY ([Files_ID])
    REFERENCES [dbo].[Files]
        ([ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EventGallery_Files'
CREATE INDEX [IX_FK_EventGallery_Files]
ON [dbo].[EventGallery]
    ([Files_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------