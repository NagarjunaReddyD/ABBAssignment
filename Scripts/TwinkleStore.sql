USE [TwinkleStore]
GO
/****** Object:  StoredProcedure [dbo].[usp_AnualCustBilling]    Script Date: 07/28/2020 6:12:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_AnualCustBilling]
as
begin
  select FirstName,LastName, PhoneNumber,DOB,EmailId , SUM(UI.NetAmount) as TotalAmount from UserDetails UD join UserItems UI on UD.id=UI.UserId
		  group by FirstName,LastName, PhoneNumber,DOB,EmailId 
		  having  SUM(UI.NetAmount)>10000
end
GO
/****** Object:  StoredProcedure [dbo].[usp_Qualified20Discount]    Script Date: 07/28/2020 6:12:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


--use TwinkleStore
CREATE procedure [dbo].[usp_Qualified20Discount]
(
@CustId int
)

as 
begin
declare @CustType varchar(10)
declare @Eligible20 varchar(20)='No'
declare @MinDate datetime
--set @CustId=1
if exists(select count(1) from UserDetails UD inner join  UserItems UI on UD.id=UI.UserId where UD.id=@CustId)
begin
set @CustType='Old'
end

if exists( select min(DateOfPurchase) from UserDetails UD inner join  UserItems UI on UD.id=UI.UserId where UD.id=@CustId)
begin
   select @MinDate=min(DateOfPurchase) from UserDetails UD inner join  UserItems UI on UD.id=UI.UserId where UD.id=@CustId
end
if(  (YEAR(GETDATE())- YEAR(@MinDate))>=5)
begin
set @Eligible20='Yes'
end
select @Eligible20 as [Qualified]
end


GO
/****** Object:  StoredProcedure [dbo].[usp_UpCmgBdayCust]    Script Date: 07/28/2020 6:12:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[usp_UpCmgBdayCust]
as
begin
SELECT * FROM 
  dbo.UserDetails Cust
WHERE 1 = (FLOOR(DATEDIFF(dd,Cust.DOB,GETDATE()+7) / 365.25))
          -
          (FLOOR(DATEDIFF(dd,Cust.DOB,GETDATE()) / 365.25))

end
GO
/****** Object:  Table [dbo].[CustomerItemsHistory]    Script Date: 07/28/2020 6:12:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CustomerItemsHistory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[EmailId] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[DOB] [datetime] NULL,
	[city] [varchar](30) NULL,
	[state] [varchar](30) NULL,
	[IsMembership] [char](1) NULL,
	[ItemsName] [varchar](max) NULL,
	[Price] [money] NULL,
	[DateOfPurchase] [datetime] NULL,
	[NoOfItems] [int] NULL,
	[Total] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 07/28/2020 6:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Price] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 07/28/2020 6:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[enabled] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 07/28/2020 6:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Roles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 07/28/2020 6:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[UserDetails](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[FirstName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[PhoneNumber] [varchar](15) NULL,
	[EmailId] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[DOB] [datetime] NULL,
	[city] [varchar](30) NULL,
	[state] [varchar](30) NULL,
	[IsMembership] [char](1) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserItems]    Script Date: 07/28/2020 6:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserItems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ItemId] [int] NULL,
	[DateOfPurchase] [datetime] NULL,
	[NoOfItems] [int] NULL,
	[DiscAmmount] [money] NULL,
	[NetAmount] [money] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 07/28/2020 6:12:37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[RoleId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[UserItems]  WITH CHECK ADD FOREIGN KEY([ItemId])
REFERENCES [dbo].[Items] ([id])
GO
ALTER TABLE [dbo].[UserItems]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[UserDetails] ([id])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([id])
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[Login] ([id])
GO
