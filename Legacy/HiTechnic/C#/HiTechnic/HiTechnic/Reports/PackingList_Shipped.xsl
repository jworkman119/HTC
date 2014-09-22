<?xml version="1.0"?>
<!-- 
	Needed to run at command line so barcodes appear properly:
	export CLASSPATH="/home/jeremyp/Development/Projects/HiTechnic/Reports/barcode4j/build/barcode4j-fop-ext-complete.jar"
-->

<xsl:stylesheet version="2.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xs="http://www.w3.org/2001/XMLSchema" 	xmlns:fo="http://www.w3.org/1999/XSL/Format" >
	<xsl:template match="/Orders">	
		<fo:root>
	    
		    <fo:layout-master-set>
			    <fo:simple-page-master master-name="PackingList" page-width="21.5cm"
			    page-height="27.9cm" margin-top=".5cm" margin-bottom="1cm"
				    margin-left="0cm" margin-right=".5cm">
					    <fo:region-body margin="1cm" margin-top="2.5cm"/>
					    <fo:region-before/>
					    <fo:region-after extent="2cm"/>
					    <fo:region-start extent="2cm"/>
					    <fo:region-end extent="2cm"/>
				</fo:simple-page-master>
				
		    </fo:layout-master-set>
    
		    <fo:page-sequence master-reference="PackingList">
			    <fo:static-content flow-name="xsl-region-before">    
				    <xsl:apply-templates select="Header"/>
			    </fo:static-content>
				
			    <fo:static-content flow-name="xsl-region-after">
				    <xsl:call-template name="Footer"/>
			    </fo:static-content>
					    				    
			    <fo:flow flow-name="xsl-region-body">
				    <xsl:apply-templates select="Order"/>
			    </fo:flow>

			</fo:page-sequence>
	    </fo:root>
      </xsl:template>

    <xsl:template match = "Header">    
	    <!-- Header Test -->
	    <fo:table table-layout="fixed">
		    <fo:table-column column-width="25%"/>
		    <fo:table-column column-width="50%"/>
		    <fo:table-column column-width="25%"/>
		    
		    <fo:table-body>
			    <fo:table-row>
				    
				    <fo:table-cell>
					    <fo:block>
						    <fo:block font-size="7pt" font-weight="bold" text-align="left" >www.HiTechnic.com</fo:block>
						    <fo:external-graphic content-height="5em" content-width="5em" src="url(hitechnic_logo.jpg)"/>  
						    
					    </fo:block>
				    </fo:table-cell>

				    <fo:table-cell column-number="2">
					    <fo:block font-size="16pt" font-weight="bold" text-align="center">Packing List</fo:block>
					    <fo:block font-size="10pt" font-weight="normal" text-align="center">
						    <xsl:value-of select='Date'/>
					    </fo:block>
				    </fo:table-cell>
				    
			    </fo:table-row>
		    </fo:table-body>
	    </fo:table>
    </xsl:template>
      
	    <xsl:template match = "Order">
		    <?dbfo-need height="21cm" ?>
			    <fo:block>	
				    <fo:marker marker-class-name="OrderNumber" >
						<xsl:value-of select="OrderNumber"/> 
					</fo:marker>
			    </fo:block>
			    <xsl:apply-templates select="ShippingInfo"/>
			    <xsl:apply-templates select="OrderDetails"/>
			    <xsl:apply-templates select="SentInfo"/>
			    <fo:block page-break-after="always"/>
	    </xsl:template>




    <xsl:template match="ShippingInfo">
	    <fo:block>
	    <fo:table>
		    <fo:table-column column-width="5cm"/>
		    <fo:table-column column-width="9cm"/>
		    <fo:table-column column-width="6cm"/>
		    
		    <fo:table-body>
			    <fo:table-row>

				    <fo:table-cell column-number="2">
					    <fo:block font-size="10pt" font-family="sans-serif" font-weight="bold"  text-align="center" color="Black">
						    Shipping Information
					    </fo:block>
				    </fo:table-cell>
				    <fo:table-cell column-number="3">
					    <fo:block text-align="right">
						    <fo:instream-foreign-object >
							    <bc:barcode xmlns:bc="http://barcode4j.krysalis.org/ns" message="{Number}">
								    <bc:code39/>
							    </bc:barcode>
						    </fo:instream-foreign-object>
					    </fo:block>
				    </fo:table-cell>
			    
		    </fo:table-row>
		    </fo:table-body>
	    </fo:table>
	    </fo:block>
		<fo:block>
		    <fo:table>
			    <fo:table-column column-width="7cm"/>
			    <fo:table-column column-width="7cm"/>
			    
			    <fo:table-body>
				    <fo:table-row>
					    <fo:table-cell>
						    <xsl:apply-templates select="BillTo"/>
					    </fo:table-cell>
					    <fo:table-cell>
						    <xsl:apply-templates select="ShipTo"/>
					    </fo:table-cell>
				    </fo:table-row>
			    </fo:table-body>
		    </fo:table>
	    </fo:block>
	    
	    <fo:block>
		    <fo:table start-indent="2cm" table-layout="fixed" font-size="8pt" font-family="sans-serif" margin-bottom="1cm">
			    <fo:table-column column-width="2cm"/>
			    <fo:table-column column-width="8cm"/>
			    <fo:table-body>
				    <fo:table-row>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block font-weight="bold">Carrier:</fo:block>
					    </fo:table-cell>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block font-size="10pt" font-weight="bold">
							    <xsl:value-of select="Carrier"/>  
						    </fo:block>
					    </fo:table-cell>
				    </fo:table-row>
				    <fo:table-row>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block font-weight="bold">Email:</fo:block>
					    </fo:table-cell>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block>
							    <xsl:value-of select="Email"/>
						    </fo:block>
					    </fo:table-cell>
				    </fo:table-row>
				    <fo:table-row>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block font-weight="bold">Phone:</fo:block>
					    </fo:table-cell>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block>
							    <xsl:value-of select="Phone"/>
						    </fo:block>
					    </fo:table-cell>
				    </fo:table-row>
				    
				    <xsl:if test="AES">  
					    <fo:table-row>
						    <fo:table-cell padding-bottom="3pt">
							    <fo:block font-weight="bold">AES#:</fo:block>
						    </fo:table-cell>
						    
						    <fo:table-cell padding-bottom="3pt">
							    <fo:block font-size="10pt" font-weight="bold">
								    <fo:instream-foreign-object>
									    <bc:barcode xmlns:bc="http://barcode4j.krysalis.org/ns" message="{AES}">
										    <bc:code39/>
									    </bc:barcode>
								    </fo:instream-foreign-object>
							    </fo:block>
						    </fo:table-cell>
					    </fo:table-row>
				    </xsl:if>
				    
			    </fo:table-body>
		    </fo:table>
	    </fo:block>
	</xsl:template>

    <xsl:template match="BillTo">
	    <fo:table start-indent="2cm" table-layout="fixed" margin-bottom="1cm">
		    <fo:table-column column-width="7cm"/>
		    <fo:table-header>
			    <fo:table-row>
				    <fo:table-cell>
					    <fo:block font-weight="bold" font-size="8pt">Billed To:</fo:block>
				    </fo:table-cell>
			    </fo:table-row>
		    </fo:table-header>
		    
		    <fo:table-body font-size="8pt" font-family="mono" font-weight="normal">
			    <xsl:apply-templates/>                                                                                               
		    </fo:table-body>
	    </fo:table>
    </xsl:template>
    
    <xsl:template match="BillTo/*">
	    <xsl:call-template name="BuildCell">
		    <xsl:with-param name = "value" select="." as="xs:string"/>
	    </xsl:call-template>
    </xsl:template>
     
    <xsl:template match="ShipTo">
	    <fo:table start-indent="2cm" table-layout="fixed" margin-bottom="1cm">
		    <fo:table-column column-width="7cm"/>
		    <fo:table-header>
			    <fo:table-row>
				    <fo:table-cell>
					    <fo:block font-weight="bold" font-size="8pt">Shipped To:</fo:block>
				    </fo:table-cell>
			    </fo:table-row>
		    </fo:table-header>
		    
		    <fo:table-body font-size="8pt" font-family="mono" font-weight="normal">
			    <xsl:apply-templates/>                                                                                               
		    </fo:table-body>
	    </fo:table>
    </xsl:template>
    
    <xsl:template match="ShipTo/*">
	    <xsl:call-template name="BuildCell">
		    <xsl:with-param name = "value" select="." as="xs:string"/>
	    </xsl:call-template>
    </xsl:template>
    
    <xsl:template name="BuildCell">
	    <xsl:param name="value" as="xs:string" required="yes"/>
	    <xsl:variable name='Length' select='string-length($value)'/>
	    <xsl:if test="$Length > 0">
		    <fo:table-row>
		        <fo:table-cell padding-left="2cm">
				    <fo:block>
					    <xsl:value-of select='$value'/>
				    </fo:block>
			    </fo:table-cell>
		    </fo:table-row>
	    </xsl:if>
	</xsl:template>
	
	<xsl:template match = "OrderDetails">
		<fo:block font-size="10pt" font-family="sans-serif" font-weight="bold"  text-align="center" color="Black" space-before="5mm" space-after="5mm">
			Order Details
		</fo:block>
		<fo:block font-size="8pt" font-family="serif" font-weight="normal" color="Black">
			<fo:table start-indent="2cm" table-layout="fixed">
				<fo:table-column column-width="30mm"/>
				<fo:table-column column-width="75mm"/>
				<fo:table-column column-width="30mm"/>

				<fo:table-header>
					<fo:table-row>
						<fo:table-cell padding-bottom="3pt">
							<fo:block font-family="sans-serif" text-decoration="underline" font-weight="bold">Item #</fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block font-family="sans-serif" text-decoration="underline" font-weight="bold">Description</fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block font-family="sans-serif" text-decoration="underline" font-weight="bold">Qty</fo:block>
						</fo:table-cell>
						
					</fo:table-row>
				</fo:table-header>
				
				<fo:table-body font-size="8pt" font-family="mono" font-weight="normal">
					<xsl:apply-templates/>                                                                                               
				</fo:table-body>
				
			</fo:table>
		</fo:block>
	</xsl:template>
	
	<xsl:template match="Item">
		<?dbfo-need height="2in" ?>
		<fo:table-row>
			<fo:table-cell padding-bottom="15pt">
				<fo:block>
					<xsl:value-of select="Number"/>
				</fo:block>
			</fo:table-cell>
			<fo:table-cell padding-bottom="15pt">
				<fo:block>
					<xsl:value-of select="Description"/>
				</fo:block>
			</fo:table-cell>
			<fo:table-cell padding-bottom="15pt">
				<fo:block>
					<xsl:value-of select="Qty"/>
				</fo:block>
			</fo:table-cell>
		</fo:table-row>
	</xsl:template>
	
	<xsl:template match="SentInfo">
		<fo:block>
			<fo:marker marker-class-name="Tracking" >
				<xsl:value-of select="Tracking"/> 
			</fo:marker>
			<fo:marker marker-class-name="Carrier" >
				<xsl:value-of select="Carrier"/> 
			</fo:marker>
			<fo:marker marker-class-name="ShippedDate" >
				<xsl:value-of select="ShippedDate"/> 
			</fo:marker>
			<fo:marker marker-class-name="Weight" >
				<xsl:value-of select="Weight"/> 
			</fo:marker>
			<fo:marker marker-class-name="ShipCost" >
				<xsl:value-of select="ShipCost"/> 
			</fo:marker>
	</fo:block>
	</xsl:template>
	
	<xsl:template  name="Footer">

				<fo:table start-indent="1.25cm" table-layout="fixed">
				<fo:table-column column-width = "20%" />
				<fo:table-column column-width = "30%" />
				<fo:table-column column-width = "18%" />
				<fo:table-column column-width = "15%" />
			
				
				<fo:table-body font-size="8pt" font-family="mono" font-weight="normal">
					<fo:table-row>
						<fo:table-cell padding-bottom="3pt">
							<fo:block text-align="right">Tracking: </fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block>
								<fo:retrieve-marker retrieve-class-name="Tracking"/>
							</fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block text-align="right">Weight: </fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block>
								<fo:retrieve-marker retrieve-class-name="Weight"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
					
					<fo:table-row>
						<fo:table-cell padding-bottom="3pt">
							<fo:block text-align="right">Carrier: </fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block>
								<fo:retrieve-marker retrieve-class-name="Carrier"/>
							</fo:block>
						</fo:table-cell>

					    <fo:table-cell padding-bottom="3pt">
						    <fo:block text-align="right">Ship Cost: </fo:block>
					    </fo:table-cell>
					    <fo:table-cell padding-bottom="3pt">
						    <fo:block>
							    <fo:retrieve-marker retrieve-class-name="ShipCost"/>
						    </fo:block>
					    </fo:table-cell>
					</fo:table-row>
					
					<fo:table-row>
						<fo:table-cell padding-bottom="3pt">
							<fo:block text-align="right">Shipped Date: </fo:block>
						</fo:table-cell>
						<fo:table-cell padding-bottom="3pt">
							<fo:block>
								<fo:retrieve-marker retrieve-class-name="ShippedDate"/>
							</fo:block>
						</fo:table-cell>
					</fo:table-row>
				</fo:table-body>
			</fo:table>
	    
	</xsl:template>

</xsl:stylesheet>	

