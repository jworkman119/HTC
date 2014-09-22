<?xml version="1.0"?>
<!-- 
	Needed to run at command line so barcodes appear properly:
	export CLASSPATH="/home/jeremyp/Development/Projects/HiTechnic/Reports/barcode4j/build/barcode4j-fop-ext-complete.jar"
-->

<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" 	xmlns:fo="http://www.w3.org/1999/XSL/Format" >	
	<xsl:template match="/MonthlyActivityLog">	
		<fo:root>
	    
		    <fo:layout-master-set>
			    <fo:simple-page-master master-name="MonthlyActivityLog" page-width="21.5cm"
			    page-height="27.9cm" margin-top=".5cm" margin-bottom="1cm"
				    margin-left="0cm" margin-right=".5cm">
					    <fo:region-body margin="1cm" margin-top="2.5cm"/>
					    <fo:region-before/>
					    <fo:region-after extent="2cm"/>
					    <fo:region-start extent="2cm"/>
					    <fo:region-end extent="2cm"/>
				</fo:simple-page-master>
				
		    </fo:layout-master-set>
    
		    <fo:page-sequence master-reference="MonthlyActivityLog">
			    <fo:static-content flow-name="xsl-region-before">    
				    <xsl:apply-templates select="Header"/>
			    </fo:static-content>
<!--				
			    <fo:flow flow-name="xsl-region-body">
				    <xsl:apply-templates select="Order"/>
			    </fo:flow>
-->
			</fo:page-sequence>
	    </fo:root>
      </xsl:template>
	  
	      <xsl:template match = "Header" margin-bottom = "2cm">    
	    <!-- Header Test -->
	    <fo:table table-layout="fixed" width="100%">
		    <fo:table-column column-width="15%"/>
		    <fo:table-column column-width="70%"/>
		    <fo:table-column column-width="15%"/>
		    
		    <fo:table-body>
			    <fo:table-row>
				    
				    <fo:table-cell>
					    <fo:block>
						    <fo:block font-size="7pt" font-weight="bold" text-align="center" >Monthly Activity Log</fo:block>
							<fo:external-graphic src="url(Pinnacle.jpg)"/>   
						    
					    </fo:block>
				    </fo:table-cell>

				    <fo:table-cell column-number="2">
					    <fo:block font-size="16pt" font-weight="bold" text-align="center">Monthly Activity Log</fo:block>
					    <fo:block font-size="10pt" font-weight="normal" text-align="center">
						    <xsl:value-of select='Date'/>
					    </fo:block>
				    </fo:table-cell>
				    
					<fo:table-cell column-number="3">
						<fo:block text-align="right">

					    </fo:block>
					</fo:table-cell>
			    </fo:table-row>
		    </fo:table-body>
	    </fo:table>
    </xsl:template>
</xsl:stylesheet>		