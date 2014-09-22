<?xml version="1.0"?>
<!-- 
	Needed to run at command line so barcodes appear properly:
	export CLASSPATH="/home/jeremyp/Development/Projects/HiTechnic/Reports/barcode4j/build/barcode4j-fop-ext-complete.jar"
-->

    

<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" 	xmlns:fo="http://www.w3.org/1999/XSL/Format">	
	<xsl:template match="/MonthlyActivityLog">	
		<fo:root>
	    
		    <fo:layout-master-set>
			    <fo:simple-page-master master-name="MonthlyActivityLog" page-width="21.5cm"
			    page-height="27.9cm" margin-top=".5cm" margin-bottom="1cm"
				    margin-left="0cm" margin-right=".5cm">
					    <fo:region-body margin="1cm" margin-top="3.5cm"/>
					    <fo:region-before margin-bottom="2cm"/>
					    <fo:region-after/>
					    <fo:region-start extent="2cm"/>
					    <fo:region-end extent="2cm"/>
				</fo:simple-page-master>
				
		    </fo:layout-master-set>
    
		    <fo:page-sequence master-reference="MonthlyActivityLog">
			    <fo:static-content flow-name="xsl-region-before">    
				    <xsl:apply-templates select="Header"/>
			    </fo:static-content>
				
				<fo:static-content flow-name="xsl-region-after">    
						<xsl:apply-templates select="Footer"/>
			    </fo:static-content>
				
			    <fo:flow flow-name="xsl-region-body">
				    <xsl:apply-templates select="Body"/>
			    </fo:flow>
			
			
			</fo:page-sequence>
	    </fo:root>
      </xsl:template>
	  	
	   <xsl:template match = "Header" margin-bottom = "2cm">    
	    <!-- Header Test -->
			<fo:block>
<!--				<fo:external-graphic padding-left="6.75cm" src="url(C:\Program~1\HTC\Pinnacle\Reports\HTC_Logo.jpg)"/>  
-->
				<fo:external-graphic padding-left="6.75cm" src="url(C:\Users\jeremyp.HTC\Documents\Development\Pinnacle\Reports\HTC_Logo.jpg)"/>  
				<fo:block font-size="14pt" font-weight="bold" text-align="center">Monthly Activity Report</fo:block>
				<fo:block padding-top="2mm"  font-size="12pt" font-weight="normal" text-align="center">
					<fo:block>
						<xsl:value-of select='Month'/><xsl:text>&#160;</xsl:text><xsl:value-of select='Year'/>
					</fo:block>
				</fo:block>
			</fo:block>
			
		</xsl:template>
		
		<xsl:template match = "Footer">
			<fo:block font-size="9pt">
				<xsl:text>Employment Specialist Signature: &#160;&#160; _______________________________________</xsl:text>
				<xsl:text>&#160;Date:&#160;&#160;____________</xsl:text>
				
			</fo:block>
		</xsl:template>
		
		
		<xsl:template match = "body">
			<xsl:apply-templates select="Consumer"/>
			<xsl:apply-templates select="Reviews"/>
			<xsl:apply-templates select="Barriers"/>
		</xsl:template>
		
		<xsl:template match = "Consumer">
				<fo:block padding-top="1cm">
				    <fo:block font-size="10pt" font-weight="bold" text-align="center">
						<xsl:value-of select="Name"/>
						<xsl:text>&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;&#160;SSN:</xsl:text> <fo:inline font-family="verdana" font-size="10pt" font-weight="normal"><xsl:value-of select='SSN'/></fo:inline>
					</fo:block>		
			    </fo:block>
			 
	    </xsl:template>	
		
		<xsl:template match = "Reviews">
			<fo:block padding-top="1cm" font-size="10pt" font-weight="normal">
				<fo:table table-layout="fixed" width="100%" padding-bottom="1cm">
					<fo:table-column column-width="30%"/>
					<fo:table-column column-width="70%"/>

					<fo:table-body>	
						
						<fo:table-row>
							<fo:table-cell padding-bottom="1mm">
								<fo:block text-align="center" text-decoration="underline" font-weight="bold">
									Date
								</fo:block>
							</fo:table-cell>
							
							<fo:table-cell padding-bottom="1mm" text-decoration="underline" font-weight="bold">
								<fo:block text-align="Left">
									Activity
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
						<xsl:apply-templates select="Review"/>

						
						<fo:table-row>
							<fo:table-cell padding-bottom='2mm'><fo:block/></fo:table-cell>
							<fo:table-cell padding-bottom='2mm' padding-top="2mm">
								<fo:block text-align="right" font-size="9pt">
									<xsl:text>Total Hours:&#160;</xsl:text><fo:inline font-family="verdana" font-size="10pt"><xsl:value-of select='TotalHours'/></fo:inline>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
						
					</fo:table-body>

				</fo:table>
			</fo:block>
		</xsl:template>
		
		<xsl:template match = "Review">
			<fo:table-row >
				<fo:table-cell>
					<fo:block padding-before='3mm' text-align="center">
						<xsl:value-of select='Date'/>
					</fo:block>
				</fo:table-cell>
				<fo:table-cell  padding-before='3mm' padding-after='1mm' border-after-style="solid">
					<fo:table table-layout="fixed" width="100%">
						<fo:table-column column-width="50%"/>
						<fo:table-column column-width="50%"/>
						
						<fo:table-body>
							<fo:table-row>
								<fo:table-cell padding-bottom='2mm'>
									<fo:block text-align="left" font-size="9pt">
										<xsl:text>Staff:&#160;</xsl:text><fo:inline font-family="verdana" font-size="10pt"><xsl:value-of select='Staff'/></fo:inline>
									</fo:block>
								</fo:table-cell>
								<fo:table-cell padding-bottom='2mm'>
									<fo:block text-align="left" font-size="9pt">
										<xsl:text>Meeting Type:&#160;</xsl:text><fo:inline font-family="verdana" font-size="10pt"><xsl:value-of select='MeetingType'/></fo:inline>
									</fo:block>
								</fo:table-cell>
							</fo:table-row>
							
							<fo:table-row>
								<fo:table-cell padding-bottom='2mm'>
									<fo:block text-align="left" font-size="9pt">
										<xsl:text>Employer:&#160;</xsl:text> <fo:inline font-family="verdana" font-size="10pt"><xsl:value-of select='Employer'/></fo:inline>										
									</fo:block>
								</fo:table-cell>
								<fo:table-cell padding-bottom='2mm'>
									<fo:block text-align="left" font-size="9pt">
										<xsl:text>Time:&#160;</xsl:text><fo:inline font-family="verdana" font-size="10pt"><xsl:value-of select='TimeIn'/>&#160; - &#160;<xsl:value-of select='TimeOut'/></fo:inline>
										<xsl:text>&#160;&#160;&#160;&#160;Hours:&#160;</xsl:text><fo:inline font-family="verdana" font-size="10pt"><xsl:value-of select='Hours'/>&#160;&#160;</fo:inline>
									</fo:block>
								</fo:table-cell>		
							</fo:table-row>
						</fo:table-body>
					</fo:table>
					<fo:block text-align="left" font-family="verdana" linefeed-treatment="preserve">
						<xsl:value-of select='Note'/>
					</fo:block>
				</fo:table-cell>
			</fo:table-row>
		</xsl:template>

		<xsl:template match = "Barriers">
			<fo:block margin-left="30%" padding-before="1cm">
				<fo:block font-size="10pt" font-weight="bold" text-decoration="underline" padding-before="3mm">
					<xsl:text>Barriers to Placement</xsl:text>
				</fo:block>
				
				<xsl:apply-templates select="Barrier"/>
			</fo:block>
		</xsl:template>
		
		<xsl:template match="Barrier">
			<fo:list-block space-before="5pt">
				<fo:list-item>
					<fo:list-item-label end-indent="label-end()">
						<fo:block>*</fo:block>
					</fo:list-item-label>

					<fo:list-item-body>
					<fo:block start-indent="32%" font-size="10pt" font-family="verdana">
						<xsl:value-of select='Item'/>
					</fo:block>
				  </fo:list-item-body>
				</fo:list-item>
			</fo:list-block>
		</xsl:template>
</xsl:stylesheet>		