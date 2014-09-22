<?xml version="1.0"?>
<!-- 
	Needed to run at command line so barcodes appear properly:
	export CLASSPATH="/home/jeremyp/Development/Projects/HiTechnic/Reports/barcode4j/build/barcode4j-fop-ext-complete.jar"
-->

    

<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" 	xmlns:fo="http://www.w3.org/1999/XSL/Format">	
	<xsl:template match="/ActivityLog">	
		<fo:root>
	    
		    <fo:layout-master-set>
			    <fo:simple-page-master master-name="ActivityLog" page-width="21.5cm"
			    page-height="27.9cm" margin-top=".5cm" margin-bottom="1cm"
				    margin-left="0cm" margin-right=".5cm">
					    <fo:region-body margin="1cm" margin-top="2.5cm"/>
					    <fo:region-before/>
					    <fo:region-after/>
					    <fo:region-start extent="2cm"/>
					    <fo:region-end extent="2cm"/>
				</fo:simple-page-master>
				
		    </fo:layout-master-set>
    
		    <fo:page-sequence master-reference="ActivityLog">
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
				<fo:external-graphic padding-left="6.75cm" src="url(C:\Program Files\HTC\Pinnacle\Reports\Pinnacle.jpg)"/>  
				<fo:block font-size="14pt" font-weight="bold" text-align="center">Extended Services Activity Report</fo:block>
				<fo:block padding-top="2mm" font-size="12pt" font-weight="normal" text-align="center">
					<fo:block>
						<xsl:value-of select='Month'/><xsl:text>&#160;</xsl:text><xsl:value-of select='Year'/>
					</fo:block>
				</fo:block>
			</fo:block>
			
		</xsl:template>
		
		<xsl:template match = "Footer">
			<fo:block font-size="9pt">
				<xsl:text>Employment Specialist Signature: &#160;&#160; ___________________________________________</xsl:text>
				<xsl:text>&#160;Date:&#160;&#160;____________</xsl:text>
				
			</fo:block>
		</xsl:template>
		
		
		<xsl:template match = "Body">
				
			<fo:block padding-top="5mm" font-size="10pt" font-weight="normal" text-align="left" margin-left="3cm">
					<fo:table table-layout="fixed" width="70%" padding-bottom="1cm">
						<fo:table-column column-width="18%"/>
						<fo:table-column column-width="80%"/>
						
						<fo:table-body>
							<fo:table-row>
								<fo:table-cell padding-bottom="1mm">
									<fo:block font-size="9pt">
										Consumer:
									</fo:block>
								</fo:table-cell>
								<fo:table-cell padding-bottom="1mm">
									<fo:block font-size="10pt" font-weight="bold">
										<xsl:value-of select="Consumer"/>
									</fo:block>	
								</fo:table-cell>
							</fo:table-row>
						
							
							
							<xsl:apply-templates select="Employer"/>
							
						</fo:table-body>
					</fo:table>
				</fo:block>

				<fo:block>
					<xsl:apply-templates select="Review"/>
				</fo:block>

		</xsl:template>

		<xsl:template match = "Employer">
			<fo:table-row font-size="10pt">
				<fo:table-cell padding-bottom="1mm">
					<fo:block font-size="9pt">
						Employer:
					</fo:block>
				</fo:table-cell>
				<fo:table-cell padding-bottom="1mm">
					<fo:block>
						<xsl:value-of select="Name"/>
					</fo:block>
				</fo:table-cell>
			</fo:table-row>
			
			<xsl:apply-templates select="Location"/>
		</xsl:template>
		
		<xsl:template match="Location">
			<fo:table-row>
				<fo:table-cell padding-bottom="1mm">
					<fo:block/>
				</fo:table-cell>
				<fo:table-cell padding-bottom="1mm">
					<fo:block font-family="verdana">
						<xsl:value-of select="Address"/>
					</fo:block>
				</fo:table-cell>
			</fo:table-row>
			
			<fo:table-row>
				<fo:table-cell padding-bottom="1mm">
					<fo:block/>
				</fo:table-cell>
				<fo:table-cell padding-bottom="1mm">
					<fo:block font-family="verdana">
						<xsl:value-of select="CityStateZip"/>
					</fo:block>
				</fo:table-cell>
			</fo:table-row>
		</xsl:template>
		
		<xsl:template match = "Review">
			<fo:block padding-top="8mm" font-size="10pt" font-weight="normal" text-align="left" margin-left="2cm">
				<xsl:apply-templates select="Info"/>
				
				<fo:block padding-top="5mm">
				<fo:table table-layout="fixed" width="95%">
					<fo:table-column column-width="18%"/>
					<fo:table-column column-width="82%"/>
					<fo:table-body>
						<fo:table-row >
							<fo:table-cell padding-bottom="5mm">
								<fo:block font-size="9pt">
									Valued&#160;Outcome:
								</fo:block>
							</fo:table-cell>
							
							<fo:table-cell padding-bottom="5mm">
								<fo:block font-family="verdana">
									<xsl:value-of select="ValuedOutcome"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
						
						<fo:table-row >
							<fo:table-cell padding-bottom="5mm">
								<fo:block font-size="9pt">
									Barriers:
								</fo:block>
							</fo:table-cell>
							
							<fo:table-cell padding-bottom="5mm">
								<fo:block font-family="verdana">
									<xsl:value-of select="Barriers"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
						
						<fo:table-row>
							<fo:table-cell padding-bottom="5mm">
								<fo:block font-size="9pt">
									Notes:
								</fo:block>
							</fo:table-cell>
						
							<fo:table-cell padding-bottom="5mm">
								<fo:block font-family="verdana" linefeed-treatment="preserve">
									<xsl:value-of select="Notes"/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
					</fo:table-body>
				</fo:table>
				</fo:block>
			</fo:block>
		</xsl:template>
		
		<xsl:template match = "Info">
			
					<fo:table table-layout="fixed" width="80%" padding-bottom="1cm">
							<fo:table-column column-width="22%"/>
							<fo:table-column column-width="28%"/>
							<fo:table-column column-width="22%"/>
							<fo:table-column column-width="28%"/>
							
							<fo:table-body>
								<fo:table-row>
									<fo:table-cell>
										<fo:block font-size="9pt">
											Review&#160;Date:
										</fo:block>
									</fo:table-cell>
							
									<fo:table-cell>
										<fo:block font-family="verdana">
											<xsl:value-of select="Date"/>
										</fo:block>
									</fo:table-cell>
									
									<fo:table-cell>
										<fo:block font-size="9pt">
											Meeting&#160;Type:
										</fo:block>
									</fo:table-cell>
									
									<fo:table-cell>
										<fo:block font-family="verdana">
											<xsl:value-of select="MeetingType"/>
										</fo:block>
									</fo:table-cell>
								</fo:table-row>
							</fo:table-body>
					</fo:table>
			
			
		</xsl:template>
		
</xsl:stylesheet>		