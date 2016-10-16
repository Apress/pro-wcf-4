/**
 * FileServiceTest.java This file was auto-generated from WSDL by the Apache
 * Axis2 version: 1.0 May 04, 2006 (09:21:04 IST)
 */
package org.tempuri;


/*
 *  FileServiceTest Junit test case
*/
public class FileServiceTest extends junit.framework.TestCase {
    /**
     * Auto generated test method
     */
    public void testSayHello() throws java.lang.Exception {
        org.tempuri.FileServiceStub stub = new org.tempuri.FileServiceStub(); //the default implementation should point to the right endpoint

        org.apache.axiom.om.OMElement param4 = (org.apache.axiom.om.OMElement) getTestObject(org.apache.axiom.om.OMElement.class);

        // todo Fill in the param4 here
        assertNotNull(stub.SayHello(param4));
    }

    //Create the desired XmlObject and provide it as the test object
    public org.apache.xmlbeans.XmlObject getTestObject(java.lang.Class type)
        throws Exception {
        java.lang.reflect.Method creatorMethod = null;

        if (org.apache.xmlbeans.XmlObject.class.isAssignableFrom(type)) {
            Class[] declaredClasses = type.getDeclaredClasses();

            for (int i = 0; i < declaredClasses.length; i++) {
                Class declaredClass = declaredClasses[i];

                if (declaredClass.getName().endsWith("$Factory")) {
                    creatorMethod = declaredClass.getMethod("newInstance", null);

                    break;
                }
            }
        }

        if (creatorMethod != null) {
            return (org.apache.xmlbeans.XmlObject) creatorMethod.invoke(null,
                null);
        } else {
            throw new Exception("Creator not found!");
        }
    }
}
