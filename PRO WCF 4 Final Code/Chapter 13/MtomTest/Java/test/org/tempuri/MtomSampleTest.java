/**
 * MtomSampleTest.java This file was auto-generated from WSDL by the Apache
 * Axis2 version: 1.0 May 04, 2006 (09:21:04 IST)
 */
package org.tempuri;


/*
 *  MtomSampleTest Junit test case
*/
public class MtomSampleTest extends junit.framework.TestCase {
    /**
     * Auto generated test method
     */
    public void testGetFile() throws java.lang.Exception {
        org.tempuri.MtomSampleStub stub = new org.tempuri.MtomSampleStub(); //the default implementation should point to the right endpoint

        org.apache.axiom.om.OMElement param4 = (org.apache.axiom.om.OMElement) getTestObject(org.apache.axiom.om.OMElement.class);

        // todo Fill in the param4 here
        assertNotNull(stub.GetFile(param4));
    }

    //Create an OMElement and provide it as the test object
    public org.apache.axiom.om.OMElement getTestObject(java.lang.Object dummy) {
        org.apache.axiom.om.OMFactory factory = org.apache.axiom.om.OMAbstractFactory.getOMFactory();
        org.apache.axiom.om.OMNamespace defNamespace = factory.createOMNamespace("",
                null);

        return org.apache.axiom.om.OMAbstractFactory.getOMFactory()
                                                    .createOMElement("test",
            defNamespace);
    }
}
