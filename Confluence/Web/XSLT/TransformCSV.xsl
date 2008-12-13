<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text" encoding="iso-8859-1"/>
  <xsl:template match="/*/child::*">
    <xsl:for-each select="child::*">
      <xsl:if test="position() != last()"><xsl:value-of select="."/>,</xsl:if>
      <xsl:if test="position()  = last()"><xsl:value-of select="."/><xsl:text>&#x0D;&#x0A;</xsl:text></xsl:if>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>

