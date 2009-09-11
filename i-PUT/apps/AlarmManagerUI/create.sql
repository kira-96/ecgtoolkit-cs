/***************************************************************************
Copyright 2009, Thoraxcentrum, Erasmus MC, Rotterdam, The Netherlands

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

	http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

Written by Maarten JB van Ettinger.

****************************************************************************/
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;

CREATE TABLE [dbo].[t_Alarm](
	[AlarmId] [nvarchar](64) NOT NULL,
	[MessageId] [nvarchar](64) NOT NULL,
	[AlarmTime] [datetime] NOT NULL,
	[PatientId] [nvarchar](64) NOT NULL,
	[Name] [nvarchar](64) NOT NULL,
	[CareUnit] [nvarchar](64) NOT NULL,
	[Bed] [nvarchar](64) NOT NULL,
	[Message] [nvarchar](128) NOT NULL,
	[AlertType] [nvarchar](64) NOT NULL,
	[ParamCode] [nvarchar](64) NOT NULL,
	[AbnormalFlag] [nvarchar](16) NOT NULL,
	[AlarmSource] [nvarchar](16) NOT NULL,
	[InsertTime] [datetime] NOT NULL CONSTRAINT [DF_t_Alarm_InsertTime]  DEFAULT (getdate()),
	CONSTRAINT [PK_t_Alarm] PRIMARY KEY CLUSTERED 
	(
		[AlarmId] ASC
	)
);

CREATE TABLE [dbo].[t_Dissemination](
	[MessageId] [nvarchar](64) NOT NULL,
	[Disseminator] [nvarchar](64) NOT NULL,
	[Location] [nvarchar](256) NOT NULL,
	[Result] [ntext] NOT NULL,
	[InsertTime] [datetime] NOT NULL CONSTRAINT [DF_t_Dissemination_InsertTime]  DEFAULT (getdate())
);

/****** Object:  Index [IX_t_Dissemination]    Script Date: 08/27/2009 11:38:03 ******/
CREATE NONCLUSTERED INDEX [IX_t_Dissemination] ON [dbo].[t_Dissemination] 
(
	[MessageId] ASC
);

/****** Object:  Index [IX_t_Dissemination_1]    Script Date: 08/27/2009 14:17:19 ******/
CREATE NONCLUSTERED INDEX [IX_t_Dissemination_1] ON [dbo].[t_Dissemination] 
(
	[Disseminator] ASC
);

/****** Object:  Index [IX_t_Dissemination_2]    Script Date: 08/27/2009 14:17:38 ******/
CREATE NONCLUSTERED INDEX [IX_t_Dissemination_2] ON [dbo].[t_Dissemination] 
(
	[InsertTime] ASC
);

CREATE TABLE [dbo].[t_HL7AlarmMessage](
	[MessageId] [nvarchar](64) NOT NULL,
	[Message] [ntext] NOT NULL,
	[OriginIP] [nvarchar](32) NOT NULL,
	[InsertTime] [datetime] NOT NULL CONSTRAINT [DF_t_HL7AlarmMessage_InsertTime]  DEFAULT (getdate()),
	CONSTRAINT [PK_t_HL7AlarmMessage] PRIMARY KEY CLUSTERED 
	(
		[MessageId] ASC
	)
);

CREATE TABLE [dbo].[t_State](
	[AlarmId] [nvarchar](64) NOT NULL,
	[MessageId] [nvarchar](64) NULL,
	[Disseminator] [nvarchar](64) NULL,
	[AlarmPriority] [nvarchar](16) NOT NULL,
	[AlarmState] [int] NOT NULL,
	[EventPhase] [int] NOT NULL,
	[InactivationState] [int] NOT NULL,
	[InsertTime] [datetime] NOT NULL CONSTRAINT [DF_t_State_InsertTime]  DEFAULT (getdate()),
	CONSTRAINT [PK_t_State] PRIMARY KEY CLUSTERED 
	(
		[AlarmId] ASC,
		[InsertTime] ASC
	)
);
