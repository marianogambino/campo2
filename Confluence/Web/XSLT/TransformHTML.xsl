<?xml version="1.0" encoding="utf-8"?>

<xsl:stylesheet version="1.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="text" encoding="iso-8859-1"/>
  <xsl:template match="/">
      <html>
      <body>
        <h1>CV del recurso Humano</h1>
        <h2>Datos Personales</h2>
        <b>Nombre:</b> <xsl:value-of select="cv/name"/><br/>
        <b>Mail:</b> <xsl:value-of select="cv/mail"/><br />
        <b>Pais:</b> <xsl:value-of select="cv/country"/><br/>
        <b>Provincia/Estado:</b> <xsl:value-of select="cv/state"/><br/>
        
        <h3>Estudios:</h3>
        
        <ul>
          <xsl:for-each select="cv/studies/study">
          <li>
            Instituto '<xsl:value-of select="institute"/>' (desde <xsl:value-of select="yearStart"/> hasta <xsl:value-of select="yearEnd"/>)
          </li>
          </xsl:for-each>
        </ul>
        
        <h3>Experiencia Laboral:</h3>
        
        <ul>
          <xsl:for-each select="cv/jobs/job">
            <li>
              Lugar '<xsl:value-of select="place"/>' (desde <xsl:value-of select="yearStart"/> hasta <xsl:value-of select="yearEnd"/>)
            </li>
          </xsl:for-each>
        </ul>
        <br/>
        Gracias por elegiar Confluence RRHH como solución en recursos humanos!
      </body>
      </html>
  </xsl:template>

</xsl:stylesheet> 

