<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output omit-xml-declaration="yes"/>
  <xsl:template match="@*|node()">
    <xsl:copy>
      <xsl:apply-templates select="@*|node()"/>
    </xsl:copy>
  </xsl:template>
  <xsl:template match="hair_color_gradient_points">
    <xsl:copy>
      <hair_color_gradient_point point="0.00, 0.00, 0.00" />
      <hair_color_gradient_point point="1.00, 1.00, 1.00" />
      <hair_color_gradient_point point="1.00, 0.00, 0.00" />
      <hair_color_gradient_point point="0.00, 1.00, 0.00" />
      <hair_color_gradient_point point="0.00, 0.00, 1.00" />      
      <hair_color_gradient_point point="0.00, 1.00, 1.00" />
      <hair_color_gradient_point point="1.00, 0.00, 1.00" />
      <hair_color_gradient_point point="1.00, 1.00, 0.00" />
      <xsl:copy-of select="@*"/>
      <xsl:copy-of select="node()"/>
    </xsl:copy>
  </xsl:template>
</xsl:stylesheet>