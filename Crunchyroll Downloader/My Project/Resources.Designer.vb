﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Dieser Code wurde von einem Tool generiert.
'     Laufzeitversion:4.0.30319.42000
'
'     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
'     der Code erneut generiert wird.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System

Namespace My.Resources
    
    'Diese Klasse wurde von der StronglyTypedResourceBuilder automatisch generiert
    '-Klasse über ein Tool wie ResGen oder Visual Studio automatisch generiert.
    'Um einen Member hinzuzufügen oder zu entfernen, bearbeiten Sie die .ResX-Datei und führen dann ResGen
    'mit der /str-Option erneut aus, oder Sie erstellen Ihr VS-Projekt neu.
    '''<summary>
    '''  Eine stark typisierte Ressourcenklasse zum Suchen von lokalisierten Zeichenfolgen usw.
    '''</summary>
    <Global.System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0"),  _
     Global.System.Diagnostics.DebuggerNonUserCodeAttribute(),  _
     Global.System.Runtime.CompilerServices.CompilerGeneratedAttribute(),  _
     Global.Microsoft.VisualBasic.HideModuleNameAttribute()>  _
    Friend Module Resources
        
        Private resourceMan As Global.System.Resources.ResourceManager
        
        Private resourceCulture As Global.System.Globalization.CultureInfo
        
        '''<summary>
        '''  Gibt die zwischengespeicherte ResourceManager-Instanz zurück, die von dieser Klasse verwendet wird.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend ReadOnly Property ResourceManager() As Global.System.Resources.ResourceManager
            Get
                If Object.ReferenceEquals(resourceMan, Nothing) Then
                    Dim temp As Global.System.Resources.ResourceManager = New Global.System.Resources.ResourceManager("Crunchyroll_Downloader.Resources", GetType(Resources).Assembly)
                    resourceMan = temp
                End If
                Return resourceMan
            End Get
        End Property
        
        '''<summary>
        '''  Überschreibt die CurrentUICulture-Eigenschaft des aktuellen Threads für alle
        '''  Ressourcenzuordnungen, die diese stark typisierte Ressourcenklasse verwenden.
        '''</summary>
        <Global.System.ComponentModel.EditorBrowsableAttribute(Global.System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Friend Property Culture() As Global.System.Globalization.CultureInfo
            Get
                Return resourceCulture
            End Get
            Set
                resourceCulture = value
            End Set
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property add_background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("add_background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property add_mass_cancel() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("add_mass_cancel", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property add_mass_cancel_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("add_mass_cancel_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property add_mass_running_cancel() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("add_mass_running_cancel", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property add_mass_running_cancel_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("add_mass_running_cancel_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot;type&quot;:&quot;midroll&quot; ähnelt.
        '''</summary>
        Friend ReadOnly Property ads_midroll() As String
            Get
                Return ResourceManager.GetString("ads_midroll", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die {&quot;type&quot;:&quot;preroll&quot;,&quot;offset&quot;:0}, ähnelt.
        '''</summary>
        Friend ReadOnly Property ads_preroll() As String
            Get
                Return ResourceManager.GetString("ads_preroll", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property backgroud() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("backgroud", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property balken() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("balken", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;img id=&quot;footer_country_flag&quot; src=&quot;https://www.crunchyroll.com/i/country_flags/ ähnelt.
        '''</summary>
        Friend ReadOnly Property CC_String() As String
            Get
                Return ResourceManager.GetString("CC_String", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdSettings_Background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdSettings_Background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdSettings_Button_SafeExit() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdSettings_Button_SafeExit", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdSettings_Button_SafeExit_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdSettings_Button_SafeExit_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdsettings_setowncookie_button() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdsettings_setowncookie_button", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdsettings_setowncookie_button_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdsettings_setowncookie_button_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdsettings_setUScookie_button() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdsettings_setUScookie_button", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property crdsettings_setUScookie_button_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("crdsettings_setUScookie_button_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property credits_background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("credits_background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property DialogNotFound_Background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("DialogNotFound_Background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property DialogNotFound_Submit() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("DialogNotFound_Submit", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property DialogNotFound_Submit_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("DialogNotFound_Submit_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property download_subs() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("download_subs", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property download_subs_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("download_subs_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property Help_Background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("Help_Background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot;,&quot;resolution&quot;:&quot;adaptive&quot; ähnelt.
        '''</summary>
        Friend ReadOnly Property hls_endString() As String
            Get
                Return ResourceManager.GetString("hls_endString", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot;format&quot;:&quot;adaptive_hls&quot;, ähnelt.
        '''</summary>
        Friend ReadOnly Property hls_Value() As String
            Get
                Return ResourceManager.GetString("hls_Value", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;/body&gt;
        '''&lt;/html&gt; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlEnd() As String
            Get
                Return ResourceManager.GetString("htmlEnd", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;/a&gt;
        '''
        '''&lt;/div&gt;
        '''
        '''&lt;/div&gt;
        '''
        '''&lt;/div&gt;
        '''
        '''&lt;img alt=&quot;image error&quot; src=&quot;balken1.png&quot; class=&quot;class-balken&quot;&gt; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlnachHardSubs() As String
            Get
                Return ResourceManager.GetString("htmlnachHardSubs", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot; class=&quot;imagestyle&quot;&gt;
        '''
        '''&lt;div&gt;
        '''
        '''&lt;span class=&quot;titel&quot; dir=&quot;auto&quot;&gt; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlnachTumbnail() As String
            Get
                Return ResourceManager.GetString("htmlnachTumbnail", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;!DOCTYPE html&gt;
        '''&lt;head&gt;
        '''&lt;meta http-equiv=&quot;Content-Type&quot; content=&quot;text/html; charset=utf-8&quot;/&gt;
        '''&lt;/head&gt;
        '''&lt;html&gt;
        '''       &lt;title&gt;CRD&lt;/title&gt;
        '''              
        '''  &lt;style&gt;
        '''	.main-bg {margin:0 0 0 0;background-color:#F2F2F2;}
        '''	.div-spacer{width:16px;height:110px;display:block;margin-bottom:14px;position:relative}
        '''	.div-episode{width:804px;height:110px;display:block;margin-bottom:14px;position:relative}
        '''	.class-balken{width:820px;height:8px;display:block;margin-bottom:4px;margin-top:6px}	
        '''	.class-cc{width:36px; [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlTop() As String
            Get
                Return ResourceManager.GetString("htmlTop", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;/span&gt;
        '''
        '''&lt;div class=&quot;progressbar&quot;&gt;
        '''
        '''&lt;div class=&quot;progressbar-value&quot; style=&quot;width: 0%&quot;&gt;&lt;/div&gt;
        '''
        '''&lt;/div&gt;
        '''&lt;span  dir=&quot;auto&quot; class=&apos;percenttext&apos;&gt;0%&lt;/span&gt;
        '''&lt;div&gt;
        '''&lt;span dir=&quot;auto&quot; class=&quot;resotext&quot;&gt; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlvorAufloesung() As String
            Get
                Return ResourceManager.GetString("htmlvorAufloesung", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot;&gt; &lt;img alt=&quot;image error&quot; src=&quot;cc1.png&quot; class=&quot;class-cc&quot;&gt; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlvorHardSubs() As String
            Get
                Return ResourceManager.GetString("htmlvorHardSubs", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;/span&gt;
        '''
        '''&lt;a href=&quot;#&quot; class=&quot;cc-wert&quot; title=&quot;Softsubs: ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlvorSoftSubs() As String
            Get
                Return ResourceManager.GetString("htmlvorSoftSubs", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die 
        '''		&lt;div class=&quot;div-episode&quot;&gt;
        '''
        '''&lt;img alt=&quot;image error&quot; src=&quot; ähnelt.
        '''</summary>
        Friend ReadOnly Property htmlvorThumbnail() As String
            Get
                Return ResourceManager.GetString("htmlvorThumbnail", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Icon ähnlich wie (Symbol).
        '''</summary>
        Friend ReadOnly Property icon() As System.Drawing.Icon
            Get
                Dim obj As Object = ResourceManager.GetObject("icon", resourceCulture)
                Return CType(obj,System.Drawing.Icon)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property LoginSkip() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("LoginSkip", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property LoginSkipHover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("LoginSkipHover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot;error&quot;:false,&quot;code&quot;:&quot;ok&quot; ähnelt.
        '''</summary>
        Friend ReadOnly Property LoginSuccess() As String
            Get
                Return ResourceManager.GetString("LoginSuccess", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_add() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_add", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_background() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_background", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_browser() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_browser", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_button_download_deactivate() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_button_download_deactivate", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_button_download_default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_button_download_default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_button_download_hovert() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_button_download_hovert", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_close() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_close", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_credits_default() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_credits_default", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_credits_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_credits_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_del() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_del", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_del_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_del_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property main_settings() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("main_settings", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property settings_add_softsubs() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("settings_add_softsubs", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property settings_add_softsubs_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("settings_add_softsubs_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property SoftSubs_Baclground() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("SoftSubs_Baclground", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property softsubs_download() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("softsubs_download", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property softsubs_download_gray() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("softsubs_download_gray", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Ressource vom Typ System.Drawing.Bitmap.
        '''</summary>
        Friend ReadOnly Property softsubs_download_hover() As System.Drawing.Bitmap
            Get
                Dim obj As Object = ResourceManager.GetObject("softsubs_download_hover", resourceCulture)
                Return CType(obj,System.Drawing.Bitmap)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &lt;!DOCTYPE html&gt;
        '''&lt;html&gt;
        '''       &lt;title&gt;CRD&lt;/title&gt;
        '''              
        '''  &lt;style&gt;
        '''	.main-bg {margin:0 0 0 -36px;background-color:#757575;}
        '''	.imagestyle{width:156px;height:88px;display:block;margin-bottom:4px}	.ulStyle{margin:0 0 0 -10px;display:block;position:relative;margin-top:8px}
        '''	.ulStyle li{margin-left:12px;float:left;display:block;position:relative}
        '''	.listyle{width:156px;display:block;background:#fff;padding:16px;margin-bottom:14px;position:relative;background-color:#b5b3b3}
        '''	.progressbar{height:14px;backgro [Rest der Zeichenfolge wurde abgeschnitten]&quot;; ähnelt.
        '''</summary>
        Friend ReadOnly Property Startuphtml() As String
            Get
                Return ResourceManager.GetString("Startuphtml", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die &quot;thumbnail&quot;:{&quot;url&quot;:&quot; ähnelt.
        '''</summary>
        Friend ReadOnly Property thumbnailString() As String
            Get
                Return ResourceManager.GetString("thumbnailString", resourceCulture)
            End Get
        End Property
        
        '''<summary>
        '''  Sucht eine lokalisierte Zeichenfolge, die US cookies can&apos;t be used as long you are logged in.
        '''I delete the curremt session with the unlock, if you want to be logged in with the US cookie you need to enter you data on the left. ähnelt.
        '''</summary>
        Friend ReadOnly Property US_ToolTip() As String
            Get
                Return ResourceManager.GetString("US_ToolTip", resourceCulture)
            End Get
        End Property
    End Module
End Namespace
