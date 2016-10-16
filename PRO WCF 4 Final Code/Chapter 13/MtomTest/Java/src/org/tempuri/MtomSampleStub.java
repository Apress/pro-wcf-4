/**
 * MtomSampleStub.java This file was auto-generated from WSDL by the Apache
 * Axis2 version: 1.0 May 04, 2006 (09:21:04 IST)
 */
package org.tempuri;


/*
*  MtomSampleStub java implementation
*/
public class MtomSampleStub extends org.apache.axis2.client.Stub {
    //default axis home being null forces the system to pick up the mars from the axis2 library
    public static final java.lang.String AXIS2_HOME = null;
    protected static org.apache.axis2.description.AxisOperation[] _operations;

    //hashmaps to keep the fault mapping
    private java.util.HashMap faultExeptionNameMap = new java.util.HashMap();
    private java.util.HashMap faultExeptionClassNameMap = new java.util.HashMap();
    private java.util.HashMap faultMessageMap = new java.util.HashMap();

    /** */
    private java.util.HashMap ns2Modules = new java.util.HashMap();
    private javax.xml.namespace.QName[] opNameArray = null;

    public MtomSampleStub(
        org.apache.axis2.context.ConfigurationContext configurationContext,
        java.lang.String targetEndpoint) throws java.lang.Exception {
        //To populate AxisService
        populateAxisService();
        populateFaults();

        ////////////////////////////////////////////////////////////////////////
        org.apache.axis2.engine.AxisConfiguration axisConfiguration = configurationContext.getAxisConfiguration();
        java.util.Collection modules = axisConfiguration.getModules().values();

        for (java.util.Iterator iterator = modules.iterator();
                iterator.hasNext(); iterator.next()) {
            org.apache.axis2.description.AxisModule axisModule = (org.apache.axis2.description.AxisModule) iterator.next();
            java.lang.String[] namespaces = axisModule.getSupportedPolicyNamespaces();

            if (namespaces != null) {
                for (int i = 0; i < namespaces.length; i++) {
                    ns2Modules.put(namespaces[i], axisModule);
                }
            }
        }

        ////////////////////////////////////////////////////////////////////////
        _serviceClient = new org.apache.axis2.client.ServiceClient(configurationContext,
                _service);
        _serviceClient.getOptions().setTo(new org.apache.axis2.addressing.EndpointReference(
                targetEndpoint));

        //Set the soap version
        _serviceClient.getOptions().setSoapVersionURI(org.apache.axiom.soap.SOAP12Constants.SOAP_ENVELOPE_NAMESPACE_URI);

        ////////////////////////////////////////////////////////////////////////
        org.apache.axis2.description.AxisOperation axisOperation;

        for (java.util.Iterator iterator = _service.getChildren();
                iterator.hasNext();) {
            // Engaging the modules per AxisOperation 
            axisOperation = (org.apache.axis2.description.AxisOperation) iterator.next();
            engage(axisOperation, configurationContext.getAxisConfiguration());
        }

        ///////////////////////////////////////////////////////////////////////
    }

    /**
     * Default Constructor
     */
    public MtomSampleStub() throws java.lang.Exception {
        this("http://localhost:8080/MtomService");
    }

    /**
     * Constructor taking the target endpoint
     */
    public MtomSampleStub(java.lang.String targetEndpoint)
        throws java.lang.Exception {
        this(org.apache.axis2.context.ConfigurationContextFactory.createConfigurationContextFromFileSystem(
                AXIS2_HOME, null), targetEndpoint);
    }

    private void populateAxisService() {
        //creating the Service
        _service = new org.apache.axis2.description.AxisService("MtomSample");

        /*
         * setting the endpont policy
         */
        java.lang.String _service_policy_string = "<wsp:Policy xmlns:wsp=\"http://schemas.xmlsoap.org/ws/2004/09/policy\" xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" wsu:Id=\"WSHttpBinding_IMtomSample_policy\"><wsp:ExactlyOne><wsp:All><sp:SymmetricBinding xmlns:sp=\"http://schemas.xmlsoap.org/ws/2005/07/securitypolicy\">\n        <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:ProtectionToken>\n            <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:SpnegoContextToken sp:IncludeToken=\"http://schemas.xmlsoap.org/ws/2005/07/securitypolicy/IncludeToken/AlwaysToRecipient\">\n                <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:RequireDerivedKeys /></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:SpnegoContextToken></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:ProtectionToken><sp:AlgorithmSuite>\n            <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:Basic256 /></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:AlgorithmSuite><sp:Layout>\n            <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:Strict /></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:Layout><sp:IncludeTimestamp /><sp:OnlySignEntireHeadersAndBody /></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:SymmetricBinding><sp:Wss11 xmlns:sp=\"http://schemas.xmlsoap.org/ws/2005/07/securitypolicy\">\n        <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:MustSupportRefKeyIdentifier /><sp:MustSupportRefIssuerSerial /><sp:MustSupportRefThumbprint /><sp:MustSupportRefEncryptedKey /></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:Wss11><sp:Trust10 xmlns:sp=\"http://schemas.xmlsoap.org/ws/2005/07/securitypolicy\">\n        <wsp:Policy><wsp:ExactlyOne><wsp:All><sp:MustSupportIssuedTokens /><sp:RequireClientEntropy /><sp:RequireServerEntropy /></wsp:All></wsp:ExactlyOne></wsp:Policy></sp:Trust10><wsoma:OptimizedMimeSerialization xmlns:wsoma=\"http://schemas.xmlsoap.org/ws/2004/09/policy/optimizedmimeserialization\" /><wspe:Utf816FFFECharacterEncoding xmlns:wspe=\"http://schemas.xmlsoap.org/ws/2004/09/policy/encoding\" /><wsap10:UsingAddressing xmlns:wsap10=\"http://www.w3.org/2005/08/addressing\" /></wsp:All></wsp:ExactlyOne></wsp:Policy>";
        org.apache.axis2.description.PolicyInclude servicePolicyInclude = _service.getPolicyInclude();
        servicePolicyInclude.addPolicyElement(org.apache.axis2.description.PolicyInclude.SERVICE_POLICY,
            getPolicyFromString(_service_policy_string));

        //creating the operations
        org.apache.axis2.description.AxisOperation __operation;

        _operations = new org.apache.axis2.description.AxisOperation[1];

        __operation = new org.apache.axis2.description.OutInAxisOperation();

        __operation.setName(new javax.xml.namespace.QName("", "GetFile"));

        _operations[0] = __operation;
        _service.addOperation(__operation);
    }

    //populates the faults
    private void populateFaults() {
    }

    /**
     * Auto generated method signature
     *
     * @param param0
     *
     * @see org.tempuri.MtomSample#GetFile
     */
    public org.apache.axiom.om.OMElement GetFile(
        org.apache.axiom.om.OMElement param0) throws java.rmi.RemoteException {
        try {
            org.apache.axis2.client.OperationClient _operationClient = _serviceClient.createClient(_operations[0].getName());
            _operationClient.getOptions().setAction("http://tempuri.org/IMtomSample/GetFile");
            _operationClient.getOptions().setExceptionToBeThrownOnSOAPFault(true);

            // create SOAP envelope with that payload
            org.apache.axiom.soap.SOAPEnvelope env = null;

            //Style is Doc.
            env = toEnvelope(getFactory(_operationClient.getOptions()
                                                        .getSoapVersionURI()),
                    param0,
                    optimizeContent(
                        new javax.xml.namespace.QName("", "GetFile")));

            // create message context with that soap envelope
            org.apache.axis2.context.MessageContext _messageContext = new org.apache.axis2.context.MessageContext();
            _messageContext.setEnvelope(env);

            // add the message contxt to the operation client
            _operationClient.addMessageContext(_messageContext);

            //execute the operation client
            _operationClient.execute(true);

            org.apache.axis2.context.MessageContext _returnMessageContext = _operationClient.getMessageContext(org.apache.axis2.wsdl.WSDLConstants.MESSAGE_LABEL_IN_VALUE);
            org.apache.axiom.soap.SOAPEnvelope _returnEnv = _returnMessageContext.getEnvelope();

            java.lang.Object object = fromOM(getElement(_returnEnv, "document"),
                    org.apache.axiom.om.OMElement.class,
                    getEnvelopeNamespaces(_returnEnv));
            _messageContext.getTransportOut().getSender().cleanup(_messageContext);

            return (org.apache.axiom.om.OMElement) object;
        } catch (org.apache.axis2.AxisFault f) {
            org.apache.axiom.om.OMElement faultElt = f.getDetail();

            if (faultElt != null) {
                if (faultExeptionNameMap.containsKey(faultElt.getQName())) {
                    //make the fault by reflection
                    try {
                        java.lang.String exceptionClassName = (java.lang.String) faultExeptionClassNameMap.get(faultElt.getQName());
                        java.lang.Class exceptionClass = java.lang.Class.forName(exceptionClassName);
                        java.rmi.RemoteException ex = (java.rmi.RemoteException) exceptionClass.newInstance();

                        //message class
                        java.lang.String messageClassName = (java.lang.String) faultMessageMap.get(faultElt.getQName());
                        java.lang.Class messageClass = java.lang.Class.forName(messageClassName);
                        java.lang.Object messageObject = fromOM(faultElt,
                                messageClass, null);
                        java.lang.reflect.Method m = exceptionClass.getMethod("setFaultMessage",
                                new java.lang.Class[] { messageClass });
                        m.invoke(ex, new java.lang.Object[] { messageObject });

                        throw ex;
                    } catch (java.lang.ClassCastException e) {
                        // we cannot intantiate the class - throw the original Axis fault
                        throw f;
                    } catch (java.lang.ClassNotFoundException e) {
                        // we cannot intantiate the class - throw the original Axis fault
                        throw f;
                    } catch (java.lang.NoSuchMethodException e) {
                        // we cannot intantiate the class - throw the original Axis fault
                        throw f;
                    } catch (java.lang.reflect.InvocationTargetException e) {
                        // we cannot intantiate the class - throw the original Axis fault
                        throw f;
                    } catch (java.lang.IllegalAccessException e) {
                        // we cannot intantiate the class - throw the original Axis fault
                        throw f;
                    } catch (java.lang.InstantiationException e) {
                        // we cannot intantiate the class - throw the original Axis fault
                        throw f;
                    }
                } else {
                    throw f;
                }
            } else {
                throw f;
            }
        }
    }

    /**
     * A utility method that copies the namepaces from the SOAPEnvelope
     */
    private java.util.Map getEnvelopeNamespaces(
        org.apache.axiom.soap.SOAPEnvelope env) {
        java.util.Map returnMap = new java.util.HashMap();
        java.util.Iterator namespaceIterator = env.getAllDeclaredNamespaces();

        while (namespaceIterator.hasNext()) {
            org.apache.axiom.om.OMNamespace ns = (org.apache.axiom.om.OMNamespace) namespaceIterator.next();
            returnMap.put(ns.getPrefix(), ns.getName());
        }

        return returnMap;
    }

    ////////////////////////////////////////////////////////////////////////
    private static org.apache.ws.policy.Policy getPolicyFromString(
        java.lang.String policyString) {
        org.apache.ws.policy.util.PolicyReader prdr = org.apache.ws.policy.util.PolicyFactory.getPolicyReader(org.apache.ws.policy.util.PolicyFactory.OM_POLICY_READER);

        try {
            if ((policyString != null) && !policyString.trim().equals("")) {
                return prdr.readPolicy(new java.io.ByteArrayInputStream(
                        policyString.getBytes()));
            }
        } catch (Exception e) {
            throw new RuntimeException("cannot convert " + policyString +
                " to policy", e);
        }

        return null;
    }

    private static org.apache.ws.policy.Policy merge(
        java.lang.String policyString1, java.lang.String policyString2) {
        return (org.apache.ws.policy.Policy) getPolicyFromString(policyString1)
                                                 .merge(getPolicyFromString(
                policyString2));
    }

    private java.util.ArrayList getModules(java.util.List termsList) {
        java.util.ArrayList arrayList = new java.util.ArrayList();
        java.util.Iterator iterator = termsList.iterator();

        org.apache.ws.policy.PrimitiveAssertion pa;
        java.lang.String namespace;
        org.apache.axis2.description.AxisModule axisModule;

        while (iterator.hasNext()) {
            pa = (org.apache.ws.policy.PrimitiveAssertion) iterator.next();
            namespace = pa.getName().getNamespaceURI();
            axisModule = (org.apache.axis2.description.AxisModule) ns2Modules.get(namespace);

            if (axisModule == null) {
                // TODO
                System.err.println(
                    "Warning: cannot find a module for process PrimitiveAssertion - " +
                    pa.getName());
            }

            arrayList.add(axisModule);
        }

        return arrayList;
    }

    private void engage(
        org.apache.axis2.description.AxisDescription axisDescription,
        org.apache.axis2.engine.AxisConfiguration axisConfiguration)
        throws org.apache.axis2.AxisFault {
        org.apache.axis2.description.PolicyInclude policyInclude = axisDescription.getPolicyInclude();
        org.apache.ws.policy.Policy policy = policyInclude.getEffectivePolicy();

        if (policy == null) {
            return;
        }

        if (!policy.isNormalized()) {
            policy = (org.apache.ws.policy.Policy) policy.normalize();
        }

        org.apache.ws.policy.XorCompositeAssertion xor = (org.apache.ws.policy.XorCompositeAssertion) policy.getTerms()
                                                                                                            .get(0);

        if (xor.isEmpty()) {
            // TODO
            throw new RuntimeException("No policy alternative found");
        }

        org.apache.ws.policy.AndCompositeAssertion anAlternative = (org.apache.ws.policy.AndCompositeAssertion) xor.getTerms()
                                                                                                                   .get(0);
        java.util.List moduleList = getModules(anAlternative.getTerms());

        if (axisDescription instanceof org.apache.axis2.description.AxisService) {
            for (java.util.Iterator iterator = moduleList.iterator();
                    iterator.hasNext();) {
                ((org.apache.axis2.description.AxisService) axisDescription).engageModule((org.apache.axis2.description.AxisModule) iterator.next(),
                    axisConfiguration);
            }
        } else if (axisDescription instanceof org.apache.axis2.description.AxisOperation) {
            for (java.util.Iterator iterator = moduleList.iterator();
                    iterator.hasNext();) {
                ((org.apache.axis2.description.AxisOperation) axisDescription).engageModule((org.apache.axis2.description.AxisModule) iterator.next(),
                    axisConfiguration);
            }
        }
    }

    private boolean optimizeContent(javax.xml.namespace.QName opName) {
        if (opNameArray == null) {
            return false;
        }

        for (int i = 0; i < opNameArray.length; i++) {
            if (opName.equals(opNameArray[i])) {
                return true;
            }
        }

        return false;
    }

    //http://localhost:8080/MtomService
    private org.apache.axiom.om.OMElement fromOM(
        org.apache.axiom.om.OMElement param, java.lang.Class type,
        java.util.Map extraNamespaces) {
        return param;
    }

    private org.apache.axiom.om.OMElement toOM(
        org.apache.axiom.om.OMElement param) {
        return param;
    }

    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
        org.apache.axiom.soap.SOAPFactory factory,
        org.apache.axiom.om.OMElement param, boolean optimizeContent) {
        org.apache.axiom.soap.SOAPEnvelope envelope = factory.getDefaultEnvelope();
        envelope.getBody().addChild(param);

        return envelope;
    }

    /**
     * get the default envelope
     */
    private org.apache.axiom.soap.SOAPEnvelope toEnvelope(
        org.apache.axiom.soap.SOAPFactory factory) {
        return factory.getDefaultEnvelope();
    }
}
