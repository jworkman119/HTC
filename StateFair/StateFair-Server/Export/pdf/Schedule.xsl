<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

    <xsl:template match="/">
        <html>
            <head>
            <link href='http://fonts.googleapis.com/css?family=Droid+Sans:400,700' rel='stylesheet' type='text/css'/>
            <style type="text/css">
                td
                {
                padding: 7px;
                border: 1px solid lightgray;
                font-size: 9px;
                font-family: tahoma, verdana, arial, sans-serif;

                }

                td.header
                {
                    padding: 7px;
                    font-family: tahoma, verdana, arial, sans-serif;
                    font-weight: bold;
                    text-decoration: underline;;
                    font-size: 10;
                    text-align: center;
                }

                table
                {
                    border-collapse: collapse;
                    border: 1px solid;
                }

                #pdf
                {
/*                    page-break-after: always;  */
                }
            </style>

            </head>
            <body>
                <div id="PDF">
                    <xsl:variable name="Person" select="/Schedule/Person" as="xs:string" />
                    <center><h2><xsl:value-of select="$Person"/> Schedule</h2></center>
                        <center>
                        <table>
                                <tr>
                                    <td class="Header">Day</td>
                                    <td class="Header">Time In</td>
                                    <td class="Header">Time Out</td>
                                    <td class="Header">Zone</td>
                                </tr>
                            <xsl:for-each select="/Schedule/Day">
                                <tr>
                                    <td class="Row"><xsl:value-of select="@Date"/></td>
                                    <td class="Row"><xsl:value-of select="TimeIn"/></td>
                                    <td class="Row"><xsl:value-of select="TimeOut"/></td>
                                    <td class="Row"><xsl:value-of select="Zone"/></td>
                                </tr>

                            </xsl:for-each>

                        </table>
                        </center>
                </div>

            </body>
        </html>
    </xsl:template>

</xsl:stylesheet>