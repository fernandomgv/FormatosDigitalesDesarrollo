﻿<%@ Control Language="VB" AutoEventWireup="false" CodeFile="mensaje.ascx.vb" Inherits="CMSWebParts_MFS_mensaje" %>

<style type="text/css">
.RadNotification_Default
{
	border: 1px solid #c4c4c4;
	background-color: #ebebeb;
}

.RadNotification_Default.rnShadows
{
	box-shadow: 2px 2px 3px #b0b0b0;
	-webkit-box-shadow: 2px 2px 3px #b0b0b0;
}

.RadNotification_Default .rnTitleBar,
.RadNotification_Default .rnCommands a
{
	background-image: url('http://localhost:2797/MFS/App_Themes/REC/REC_imagenes/notificacion.png');
}

.RadNotification_Default .rnTitleBar
{
	border-bottom: 1px solid transparent;
}

.RadNotification_Default .rnContentWrapper
{
	border-top: 1px solid transparent;
}

/* base style overwrites */
.RadNotification_Default .rnCommands
{
	margin: 4px 0 0;
}



/*RadNotification Base Stylesheet*/

.RadNotification
{
	margin: 0;
	padding: 0;
	font-family: "Segoe UI",Arial,Helvetica,sans-serif;
    font-size: 12px;
    word-wrap: break-word;
    z-index: 9001;
}

.rnRoundedCorners
{
	border-radius: 5px;
}

/* Titlebar */
.rnTitleBar
{
	height: 24px;
	background-repeat: repeat-x;
	background-position: 0 0;
	margin: 0;
	padding: 0 4px;
	border-radius: 5px 5px 0 0;
}

.rnTitleBarIcon
{
	display: block;
	float: left;
	width: 16px;
	height: 16px;
	margin: 4px 4px 0 0;
	overflow: hidden;
}

.rnTitleBarTitle
{
	display: block;
	float: left;
	width: 70%;
	height: 24px;
	line-height: 24px;
	overflow: hidden;
	font-weight: bold;
}

/* Titlebar commands */
.rnCommands
{
	width: auto;
	height: 19px;
	line-height: 19px;
	float: right;
	list-style: none;
	margin: 3px 0 0 0;
	padding: 0;
}

.rnCommands li
{
	float: left;
}

.rnCommands a
{
	display: block;
	width: 19px;
	height: 19px;
}

.rnCommands .rnMenuIcon a
{
	background-position: 0 -27px;
}

.rnCommands .rnMenuIcon a:hover
{
	background-position: 21px -27px;
}

.rnCommands .rnCloseIcon a
{
	background-position: 0 -47px;
}

.rnCommands .rnCloseIcon a:hover
{
	background-position: 21px -47px;
}

.rnCommands a .rnAccessibility
{
	display: none;
}

div.rnNoTitleBar .rnContentWrapper
{
	border-top: 0;
}

/* Content */
.rnContentWrapper
{
	padding: 5px 5px 5px 5px;
	border: 0;
}

.rnContentIconClipIn
{
	position: relative;
	float: left;
	margin: -2px 0 -34px 15px;
	width: 32px;
	height: 32px;
}

*html .rnContentIconClipIn
{
	margin: -2px 0 -34px 16px;
}

*+html .rnContentIconClipIn
{
	margin: 15px 0 -35px 0;
}

.rnContentIconClip
{
	position: absolute;
	top: -1px;
	clip: rect(16px 32px 48px 0);
}


*+html .rnContentIconClip
{
	top: -18px;
	right: -18px;
}

.rnContentIconClipIn .rnCustomIcon
{
	clip: auto;
	margin-top: 12px;
}

*html .rnContentIconClipIn .rnCustomIcon
{
	cliptop: 0;
	top: 0;
}

*+html .rnContentIconClipIn .rnCustomIcon
{
	cliptop: 0;
}

.rnContent
{
	padding: 12px 20px 20px 67px;
}

.rnContentTemplate,
div.rnNoContentIcon .rnContent
{
	padding: 0;
}

/* Right to left support */

.rnRtl .rnCommands li,
.rnRtl .rnTitleBarIcon,
.rnRtl .rnTitleBarTitle,
.rnRtl .rnContentIconClipIn
{
	float: right;
}

/* We need it because of IE9 */
.rnRtl .rnTitleBarTitle
{
	padding-right: 4px;
}

div.rnRtl .rnCommands
{
	float: left;
	margin-left: -4;
}

*html div.rnRtl .rnCommands
{
	margin-top: 4px;
	margin-right: 45px;
	width: 40px;
}

*+html div.rnRtl .rnCommands
{
	margin-top: 4px;
	margin-right: 55px;
	width: 40px;
}

.rnRtl .rnTitleBarIcon
{
	direction: ltr;
	margin: 4px 0 0 0;
}

.rnRtl .rnContent 
{
    padding: 12px 67px 20px 20px;
}

.rnRtl .rnContentIconClipIn
{
	margin: -2px 15px -34px 0;
}

*html .rnRtl .rnContentIconClipIn
{
	margin: -2px 7px -34px 0;
	position: fixed;
}

*+html .rnRtl .rnContentIconClipIn
{
	margin: 15px 30px -35px 0;
	position: fixed;
}

*html .rnRtl .rnContentIconClipIn .rnCustomIcon
{
	cliptop: 0;
	top: 16px;
}

*html .rnRtl .rnContentIconClip
{
	margin-top: 25px;
}

</style>


<div id="notification_popup" 
    class="RadNotification RadNotification_Default rnRoundedCorners rnShadows" 
    style="z-index: 10000; height: 150px; visibility: visible; left: 281px; top: 106px; width: 350px; position: fixed; ">
			<div class="rnTitleBar" id="notification_titlebar">
				<span class="rnTitleBarIcon"><img src="Icons/title_icon.gif" alt=""></span><span class="rnTitleBarTitle">Sample Title</span>
			</div><div id="notification_XmlPanel" class="RadXmlHttpPanel">
				<div id="notification_C" class="rnContentWrapper" style="height: 116px; ">
					<div class="rnContentIconClipIn">
						<div class="rnContentIconClip rnCustomIcon">
							<img src="Icons/content_icon.png" alt="">
						</div>
					</div><div id="notification_simpleContentDiv" class="rnContent">ayuda</div>
				</div><input type="hidden" name="notification$hiddenState" id="notification_hiddenState"><input id="notification_XmlPanel_ClientState" name="notification_XmlPanel_ClientState" type="hidden" autocomplete="off">
			</div><div id="notification_TitleMenu" style="z-index: 7000; display: none; visibility: visible; ">
				<div class="RadMenu RadMenu_Default RadMenu_Context RadMenu_Default_Context rmRoundedCorners rmRoundedCorners_Default rmShadows " style="display: none; visibility: visible; z-index: 10100; " id="notification_TitleMenu_detached">

				<ul class="rmActive rmVertical rmGroup rmLevel1" style="float: left; "></ul></div><input class="rmActive rmVertical rmGroup rmLevel1" id="notification_TitleMenu_ClientState" name="notification_TitleMenu_ClientState" type="hidden" autocomplete="off">
			</div>
		</div>