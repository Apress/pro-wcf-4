/*
 * An XML document type.
 * Localname: ENTITY
 * Namespace: http://schemas.xmlsoap.org/soap/encoding/
 * Java type: org.xmlsoap.schemas.soap.encoding.ENTITYDocument
 *
 * Automatically generated - do not modify.
 */
package org.xmlsoap.schemas.soap.encoding;


/**
 * A document containing one ENTITY(@http://schemas.xmlsoap.org/soap/encoding/) element.
 *
 * This is a complex type.
 */
public interface ENTITYDocument extends org.apache.xmlbeans.XmlObject
{
    public static final org.apache.xmlbeans.SchemaType type = (org.apache.xmlbeans.SchemaType)
        org.apache.xmlbeans.XmlBeans.typeSystemForClassLoader(ENTITYDocument.class.getClassLoader(), "schemaorg_apache_xmlbeans.system.sD351352778AD90575D6C331E1152D169").resolveHandle("entity23f9doctype");
    
    /**
     * Gets the "ENTITY" element
     */
    org.xmlsoap.schemas.soap.encoding.ENTITY getENTITY();
    
    /**
     * Sets the "ENTITY" element
     */
    void setENTITY(org.xmlsoap.schemas.soap.encoding.ENTITY entity);
    
    /**
     * Appends and returns a new empty "ENTITY" element
     */
    org.xmlsoap.schemas.soap.encoding.ENTITY addNewENTITY();
    
    /**
     * A factory class with static methods for creating instances
     * of this type.
     */
    
    public static final class Factory
    {
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument newInstance() {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().newInstance( type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument newInstance(org.apache.xmlbeans.XmlOptions options) {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().newInstance( type, options ); }
        
        /** @param xmlAsString the string value to parse */
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.lang.String xmlAsString) throws org.apache.xmlbeans.XmlException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( xmlAsString, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.lang.String xmlAsString, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( xmlAsString, type, options ); }
        
        /** @param file the file from which to load an xml document */
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.io.File file) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( file, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.io.File file, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( file, type, options ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.net.URL u) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( u, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.net.URL u, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( u, type, options ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.io.InputStream is) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( is, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.io.InputStream is, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( is, type, options ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.io.Reader r) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( r, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(java.io.Reader r, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException, java.io.IOException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( r, type, options ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(javax.xml.stream.XMLStreamReader sr) throws org.apache.xmlbeans.XmlException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( sr, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(javax.xml.stream.XMLStreamReader sr, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( sr, type, options ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(org.w3c.dom.Node node) throws org.apache.xmlbeans.XmlException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( node, type, null ); }
        
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(org.w3c.dom.Node node, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( node, type, options ); }
        
        /** @deprecated {@link XMLInputStream} */
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(org.apache.xmlbeans.xml.stream.XMLInputStream xis) throws org.apache.xmlbeans.XmlException, org.apache.xmlbeans.xml.stream.XMLStreamException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( xis, type, null ); }
        
        /** @deprecated {@link XMLInputStream} */
        public static org.xmlsoap.schemas.soap.encoding.ENTITYDocument parse(org.apache.xmlbeans.xml.stream.XMLInputStream xis, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException, org.apache.xmlbeans.xml.stream.XMLStreamException {
          return (org.xmlsoap.schemas.soap.encoding.ENTITYDocument) org.apache.xmlbeans.XmlBeans.getContextTypeLoader().parse( xis, type, options ); }
        
        /** @deprecated {@link XMLInputStream} */
        public static org.apache.xmlbeans.xml.stream.XMLInputStream newValidatingXMLInputStream(org.apache.xmlbeans.xml.stream.XMLInputStream xis) throws org.apache.xmlbeans.XmlException, org.apache.xmlbeans.xml.stream.XMLStreamException {
          return org.apache.xmlbeans.XmlBeans.getContextTypeLoader().newValidatingXMLInputStream( xis, type, null ); }
        
        /** @deprecated {@link XMLInputStream} */
        public static org.apache.xmlbeans.xml.stream.XMLInputStream newValidatingXMLInputStream(org.apache.xmlbeans.xml.stream.XMLInputStream xis, org.apache.xmlbeans.XmlOptions options) throws org.apache.xmlbeans.XmlException, org.apache.xmlbeans.xml.stream.XMLStreamException {
          return org.apache.xmlbeans.XmlBeans.getContextTypeLoader().newValidatingXMLInputStream( xis, type, options ); }
        
        private Factory() { } // No instance of this class allowed
    }
}
