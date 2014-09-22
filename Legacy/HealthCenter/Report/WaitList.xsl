<?xml version="1.0"?>
<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" 	xmlns:fo="http://www.w3.org/1999/XSL/Format">	

		<xsl:template match="/WaitList">	
			<fo:root>
			
				<fo:layout-master-set>
					<fo:simple-page-master master-name="WaitList" page-width="21.5cm"
					page-height="27.9cm" margin-top="1.5cm" margin-bottom="1cm"
						margin-left="0cm" margin-right=".5cm">
							<fo:region-body margin="1cm" margin-top="1.5cm"/>
							<fo:region-before/>
							<fo:region-after/>
							<fo:region-start extent="2cm"/>
							<fo:region-end extent="2cm"/>
					</fo:simple-page-master>
					
				</fo:layout-master-set>
		
				<fo:page-sequence master-reference="WaitList">
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

	     <xsl:template match = "Header" margin-bottom = "1cm">
		 
	    <!-- Header Test -->
			<fo:block>
				<fo:block font-size="14pt" font-weight="bold" text-align="center">Wait List</fo:block>
				<fo:block padding-top="2mm" font-size="12pt" font-weight="normal" text-align="center">
					<fo:block>
						<xsl:value-of select='TimeFrame'/>
					</fo:block>
				</fo:block>
			</fo:block>
			
		</xsl:template>
		
		<xsl:template match = "Footer">
			<fo:table>
				<fo:table-column column-width="50%"/>
				<fo:table-column column-width="50%"/>
				
				<fo:table-body>
					<fo:table-row>
						<fo:table-cell>
							<fo:block font-size="9pt">
								<xsl:text>Date:&#160;&#160;</xsl:text>
								<xsl:value-of select='Date'/>
							</fo:block>
						</fo:table-cell>
						
						<fo:table-cell>
							<fo:block font-size="9pt" text-align="right">
								<xsl:text>Page &#160;&#160;</xsl:text>
								<fo:page-number/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
				</fo:table-body>
			</fo:table>
		</xsl:template>	
		
		
		
		<xsl:template match = "Body">
			<xsl:apply-templates select="Table"/>
		</xsl:template>
		
		<xsl:template match = "Table">
			
				<fo:block padding-top="1cm" font-size="10pt" font-weight="normal">
					<fo:table table-layout="fixed" width="110%" padding-bottom="1cm" margin-left="1.5cm">
							<fo:table-column column-width="10%"/>
							<fo:table-column column-width="25%"/>
							<fo:table-column column-width="12.5%"/>
							<fo:table-column column-width="12.5%"/>
							<fo:table-column column-width="25%"/>

							
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
					
					<xsl:for-each select='Column'>
						<fo:table-cell>
							<fo:block padding-before='3mm' text-align="left">
								<fo:inline text-decoration="underline">
									<xsl:value-of select='.'/> 
								</fo:inline>
							</fo:block>
						</fo:table-cell>
					</xsl:for-each>
					
				</fo:table-row>

		</xsl:template>
		
		<xsl:template match = "TableBody">
				
			<xsl:for-each select='Rows/Row'>

						<fo:table-row>		
							<fo:table-cell>
								<fo:block padding-before='3mm' text-align="left" font-size="10pt" font-family="sarif">
									<xsl:value-of select='Account'/>
								</fo:block>
							</fo:table-cell>

							<fo:table-cell>						
								<fo:block padding-before='3mm' text-align="left" font-size="10pt" font-family="sarif">
									<xsl:value-of select='Patient'/>
								</fo:block>
							</fo:table-cell>
							
							<fo:table-cell>
								<fo:block padding-before='3mm' text-align="left" font-size="10pt" font-family="sarif">
									<xsl:value-of select='StartDate'/>
								</fo:block>
							</fo:table-cell>						
							
							<fo:table-cell>
								<fo:block padding-before='3mm' text-align="left" font-size="10pt" font-family="sarif">
									<xsl:value-of select='EndDate'/>
								</fo:block>
							</fo:table-cell>
							
							<fo:table-cell>
								<fo:block padding-before='3mm' text-align="left" font-size="10pt" font-family="sarif">
									<xsl:value-of select='Resource'/>
								</fo:block>
							</fo:table-cell>
						</fo:table-row>
			</xsl:for-each>
	</xsl:template>
	
	

		
</xsl:stylesheet>