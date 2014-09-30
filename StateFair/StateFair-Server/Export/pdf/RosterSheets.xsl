<?xml version="1.0"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <!-- XML output mode -->
    <xsl:output method="xml" standalone="yes" indent="no" encoding="utf-8"/>
    <xsl:template match="/">
        <html>
           <head>
            <link href='http://fonts.googleapis.com/css?family=Droid+Sans:400,700' rel='stylesheet' type='text/css'/>

               <style type="text/css">
                    div.body{
                        width=800px;
                        font-size:8px;
                        font-family:  tahoma, verdana, arial, sans-serif;

                   }
                   b.supervisor{
                        font-size:12px;
                        font-weight:bold;
                        font-family:  tahoma, verdana, arial, sans-serif;
                   }

                   b.name{
                        font-size:10px;
                        font-weight:bold;
                        font-family: tahoma, verdana, arial, sans-serif;
                   }
                   div.Heading{
                       text-align: center;
                       width: 200px;
                       margin-left: 200px;
                   }
                   div.Worker{
                        margin-top: 20px;
                        margin-bottom: 5px;
                        height: 200px;
                   }
                   div.Picture{
                        margin-left: 10px;
                        float: left;
                        height: 120px;
                        width: 120px;
                   }
                   div.Info{
                        margin-left: 20px;
                        width: 450px;
                        font-weight: normal;
                        font-size:10px;
                        Float:left;
                   }
                   hr.Signature{
                        width:80px;
                        align:left;
                        size: 1px;
                   }
                   div.Signatures{
                        float: left;
                        width: 200px;
                        margin-right: 5px;

                   }
                   div.Time{
                        margin-left: 15px;
                        width: 100px;
                        float: left;

                   }
                   div.Rating{
                        margin-left: 5px;
                        width: 200px;
                        float: right;

                   }

               </style>
    
           </head>
           <body>
            <div class="body">
                <xsl:variable name="Date" select="/Roster/Day" as="xs:string" />
                <xsl:variable name="Shift" select="/Roster/Shift" as="xs:string"/>

                <xsl:for-each select="/Roster/Group">
                    <div Class="Heading">
                        <h2>Roster Sheet</h2>
                        <xsl:for-each select="Supervisor">
                            <b class="supervisor"><xsl:value-of select="@Name"/></b>
                            <br/>
                            Date: <xsl:value-of select="$Date" />
                            <br/>
                            Shift: <xsl:value-of select="$Shift"/>
                        </xsl:for-each>
                    </div>
                    <xsl:for-each select="Worker">
                        <xsl:variable name="Counter" select="position() mod 4"/>

                        <xsl:if test="$Counter=0">
                            <p style="page-break-before: always"/>
                        </xsl:if>
                        <div Class="Worker">
                            <div class="Picture">
                                <img width='100' height='100'>
                                    <xsl:attribute name="src">
                                        <xsl:value-of select="@PicPath"/>
                                    </xsl:attribute>
                                </img>
                            </div>

                            <div class="Info">
                                <b class="name"><xsl:value-of select="@Name"/></b>
                                Shift: <xsl:value-of select="@Shift"/>
                                <br/>
                                <xsl:value-of select="@Zone"/>
                                <br/>
                                Lunch <input type="checkbox"/>
                                <br/>
                                <br/>
                                Supervisor Rating (1-5): _____
                                <br/>
                                Notes/Comments:
                                <br/>
                                <hr size="100" width="400"/>

                            </div>
                        </div>

                    </xsl:for-each>

                </xsl:for-each>

                <br></br>
                </div>
            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>