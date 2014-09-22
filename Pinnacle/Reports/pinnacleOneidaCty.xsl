<?xml version="1.0"?>
<!-- 
	Needed to run at command line so barcodes appear properly:
	export CLASSPATH="/home/jeremyp/Development/Projects/HiTechnic/Reports/barcode4j/build/barcode4j-fop-ext-complete.jar"
-->

    

<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" 	xmlns:fo="http://www.w3.org/1999/XSL/Format">	
	<xsl:template match="/ReviewCosts">	
		<fo:root>
	    
		    <fo:layout-master-set>
			    <fo:simple-page-master master-name="ReviewCosts" page-width="21.5cm"
			    page-height="27.9cm" margin-top=".5cm" margin-bottom="1cm"
				    margin-left="0cm" margin-right=".5cm">
					    <fo:region-body margin="1cm" margin-top="2.5cm"/>
					    <fo:region-before/>
					    <fo:region-after/>
					    <fo:region-start extent="2cm"/>
					    <fo:region-end extent="2cm"/>
				</fo:simple-page-master>
				
		    </fo:layout-master-set>
    
		    <fo:page-sequence master-reference="ReviewCosts">
			    <fo:static-content flow-name="xsl-region-before">
					
				    <xsl:apply-templates select="Header"/>
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
<!--			
				<fo:external-graphic padding-left="6.75cm" src="url(C:\Progra~1\HTC\Pinnacle\Reports\HTC_Logo.jpg)"/>  
-->
				<fo:external-graphic padding-left="5.75cm" src="url(C:\Users\jeremyp.HTC\Documents\Development\Pinnacle\Reports\HTC_Logo.jpg)"/> 

				<fo:block font-size="14pt" font-weight="bold" text-align="center">HTC Human Resources Monthly Review Costs</fo:block>
				<fo:block padding-top="2mm" font-size="12pt" font-weight="normal" text-align="center">
					<fo:block>
						<xsl:value-of select='TimeFrame'/><xsl:text>&#160;</xsl:text><xsl:value-of select='Year'/>
					</fo:block>
				</fo:block>
			</fo:block>
			
		</xsl:template>
		
		
		<xsl:template match = "Body">
			
			<xsl:apply-templates select="Table"/>
		
		</xsl:template>
		
		<xsl:template match = "Table">
			
			<fo:block padding-top="1cm" font-size="10pt" font-weight="normal">
				<fo:table table-layout="fixed" width="105%" padding-bottom="1cm">
					<fo:table-column column-width="20%"/>
					<fo:table-column column-width="15%"/>
					<fo:table-column column-width="15%"/>
					<fo:table-column column-width="15%"/>
					<fo:table-column column-width="15%"/>
					<fo:table-column column-width="15%"/>
					
					<fo:table-header>
						
						<xsl:apply-templates select="Headers"/>
					</fo:table-header>
					
					<fo:table-body>
						<xsl:apply-templates select="TableBody"/>
					</fo:table-body>
				</fo:table>
				
				
			</fo:block>
		</xsl:template>
		
		<xsl:template match = "Headers">
				
				<fo:table-row>
					
					<fo:table-cell><fo:block/></fo:table-cell>
					
					<xsl:for-each select='Column'>
						<fo:table-cell>
							<fo:block padding-before='3mm' text-align="center">
									 <xsl:value-of select='Header'/>
									 <fo:table>
										<fo:table-body>
											<fo:table-row border-bottom-style="dashed" border-top-style="solid">
												<fo:table-cell border-right-style="dotted">
													<fo:block font-size="9pt" font-family="serif">
														Hours
													</fo:block>
												</fo:table-cell>
												
												<fo:table-cell border-right-style="solid">
													<fo:block font-size="9pt" font-family="serif">
														Cost
													</fo:block>
												</fo:table-cell>
											</fo:table-row>
										</fo:table-body>
									 </fo:table>
							</fo:block>
						</fo:table-cell>
					</xsl:for-each>
					
					
				</fo:table-row>
		</xsl:template>
		
		<xsl:template match = "TableBody">
				
				
				<xsl:for-each select='Staff'>
					<fo:table-row>
						<fo:table-cell>
							<fo:block padding-before='3mm' text-align="left" font-size="12pt" font-weight="bold" font-family="sarif">
								<xsl:value-of select='@Name'/>
							</fo:block>
						</fo:table-cell>
						
						<xsl:apply-templates select="Funds"/>
					</fo:table-row>
				</xsl:for-each>
			
		</xsl:template>
		
		<xsl:template match ='Funds'>
			<xsl:for-each select='Fund'>
				<fo:table-cell border-right-style="solid">
					<fo:table>
							<fo:table-body>
								<fo:table-row>
									<fo:table-cell height="1cm">
										<fo:block padding-before='3mm' font-size="9pt" text-align="center" font-family="serif">
											<xsl:value-of select='Hours'/>
										</fo:block>
									</fo:table-cell>
									
									<fo:table-cell height="1cm" border-left-style="dotted">
										<fo:block padding-before='3mm' font-size="9pt" text-align="center" font-family="serif">
											<xsl:value-of select='Cost'/>
										</fo:block>
									</fo:table-cell>
								</fo:table-row>
							</fo:table-body>
					</fo:table>
				</fo:table-cell>
			</xsl:for-each>	
		</xsl:template>
		
</xsl:stylesheet>		