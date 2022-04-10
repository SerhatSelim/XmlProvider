﻿using System;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace XsdValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string xsdMarkup =
                                 @"<?xml version='1.0' encoding='utf-8'?>
<xsd:schema version='1.0' elementFormDefault='qualified' attributeFormDefault='unqualified' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <xsd:element name='MyField'>
    <xsd:annotation>
      <xsd:documentation>
        MyField Display Text
      </xsd:documentation>
    </xsd:annotation>
    <xsd:simpleType>
      <xsd:restriction base='xsd:string'>
        <xsd:pattern value='([0-9]\d{3}((0[1-9]|1[012])(0[1-9]|1\d|2[0-8])|(0[13456789]|1[012])(29|30)|(0[13578]|1[02])31)|(15(8[48]|9[26])|(1[6-9]|[2-9]\d)(0[48]|[13579][26]|[2468][048])|([2468][048]|16|3579[26])00)0229)((0[0-9]|1[0-9]|2[0-3])([0-5]\d){2})' />
      </xsd:restriction>
    </xsd:simpleType>
  </xsd:element>
</xsd:schema>";

            //62710522201745
            //string xml = @"<?xml version='1.0' encoding='utf-8' ?><MyField>62710522201745</MyField>";



            //using var stringReader = new StringReader(xml);
            //XDocument doc = XDocument.Load(stringReader);
            //doc.Descendants()
            //      .Where(e => e.IsEmpty || String.IsNullOrWhiteSpace(e.Value))
            //      .Remove();

            //XmlSchemaSet schemas = new XmlSchemaSet();
            //schemas.Add("", XmlReader.Create(new StringReader(xsdMarkup)));



            var path = @"C:\06Repo\GitHub\XmlProvider\XsdValidator\pacs_008_001_08_T2.xsd";
            XmlSchemaSet schemas = new XmlSchemaSet();

            schemas.Add("urn:iso:std:iso:20022:tech:xsd:pacs.008.001.08", path);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\06Repo\GitHub\XmlProvider\XsdValidator\message.xml");
            string xmlcontents = xmlDoc.InnerXml;
            TextReader tr = new StringReader(xmlcontents);
            XDocument doc = XDocument.Load(tr);
            //doc.Descendants()
            //      .Where(e => e.IsEmpty || String.IsNullOrWhiteSpace(e.Value))
            //      .Remove();


         
            

            XmlDocument doc2 = new XmlDocument();
            doc2.LoadXml(xmlcontents);
            var temp = doc2.GetElementsByTagName("Document")[0].NamespaceURI;



            bool error = false;
            doc.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                error = true;
            });
           
 
        }

        
    }

    public static class Xml
    {
        public static readonly string XmlText = @"<?xml version='1.0' encoding='utf-16'?>
<FIToFICustomerCreditTransferV08 xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema'>
  <GrpHdr xmlns='urn:iso:std:iso:20022:tech:xsd:pacs.008.001.08'>
    <MsgId>string</MsgId>
    <CreDtTm>2021-05-24T19:46:02.378Z</CreDtTm>
    <NbOfTxs>1</NbOfTxs>
    <SttlmInf>
      <SttlmMtd>CLRG</SttlmMtd>
      <ClrSys>
        <Cd>TGT</Cd>
      </ClrSys>
    </SttlmInf>
  </GrpHdr>
  <CdtTrfTxInf xmlns='urn:iso:std:iso:20022:tech:xsd:pacs.008.001.08'>
    <PmtId>
      <InstrId>string</InstrId>
      <EndToEndId>string</EndToEndId>
      <UETR>string</UETR>
      <ClrSysRef>string</ClrSysRef>
    </PmtId>
    <PmtTpInf>
      <LclInstrm>
        <Cd>string</Cd>
      </LclInstrm>
      <CtgyPurp>
        <Cd>string</Cd>
      </CtgyPurp>
    </PmtTpInf>
    <IntrBkSttlmAmt Ccy='string'>0</IntrBkSttlmAmt>
    <IntrBkSttlmDt>2021-05-24</IntrBkSttlmDt>
    <SttlmTmIndctn>
      <CdtDtTm>2021-05-24T19:46:02.378Z</CdtDtTm>
    </SttlmTmIndctn>
    <SttlmTmReq />
    <InstdAmt Ccy='string'>0</InstdAmt>
    <ChrgBr>DEBT</ChrgBr>
    <ChrgsInf>
      <Amt Ccy='string'>0</Amt>
      <Agt>
        <FinInstnId>
          <BICFI>string</BICFI>
          <ClrSysMmbId>
            <ClrSysId>
              <Cd>string</Cd>
            </ClrSysId>
            <MmbId>string</MmbId>
          </ClrSysMmbId>
          <LEI>string</LEI>
          <Nm>string</Nm>
          <PstlAdr>
            <Dept>string</Dept>
            <SubDept>string</SubDept>
            <StrtNm>string</StrtNm>
            <BldgNb>string</BldgNb>
            <BldgNm>string</BldgNm>
            <Flr>string</Flr>
            <PstBx>string</PstBx>
            <Room>string</Room>
            <PstCd>string</PstCd>
            <TwnNm>string</TwnNm>
            <TwnLctnNm>string</TwnLctnNm>
            <DstrctNm>string</DstrctNm>
            <CtrySubDvsn>string</CtrySubDvsn>
            <Ctry>string</Ctry>
            <AdrLine>string</AdrLine>
          </PstlAdr>
        </FinInstnId>
      </Agt>
    </ChrgsInf>
    <PrvsInstgAgt1>
      <FinInstnId>
        <BICFI>string</BICFI>
        <ClrSysMmbId>
          <ClrSysId>
            <Cd>string</Cd>
          </ClrSysId>
          <MmbId>string</MmbId>
        </ClrSysMmbId>
        <LEI>string</LEI>
        <Nm>string</Nm>
        <PstlAdr>
          <Dept>string</Dept>
          <SubDept>string</SubDept>
          <StrtNm>string</StrtNm>
          <BldgNb>string</BldgNb>
          <BldgNm>string</BldgNm>
          <Flr>string</Flr>
          <PstBx>string</PstBx>
          <Room>string</Room>
          <PstCd>string</PstCd>
          <TwnNm>string</TwnNm>
          <TwnLctnNm>string</TwnLctnNm>
          <DstrctNm>string</DstrctNm>
          <CtrySubDvsn>string</CtrySubDvsn>
          <Ctry>string</Ctry>
          <AdrLine>string</AdrLine>
        </PstlAdr>
      </FinInstnId>
    </PrvsInstgAgt1>
    <PrvsInstgAgt1Acct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </PrvsInstgAgt1Acct>
    <PrvsInstgAgt2>
      <FinInstnId>
        <BICFI>string</BICFI>
        <ClrSysMmbId>
          <ClrSysId>
            <Cd>string</Cd>
          </ClrSysId>
          <MmbId>string</MmbId>
        </ClrSysMmbId>
        <LEI>string</LEI>
        <Nm>string</Nm>
        <PstlAdr>
          <Dept>string</Dept>
          <SubDept>string</SubDept>
          <StrtNm>string</StrtNm>
          <BldgNb>string</BldgNb>
          <BldgNm>string</BldgNm>
          <Flr>string</Flr>
          <PstBx>string</PstBx>
          <Room>string</Room>
          <PstCd>string</PstCd>
          <TwnNm>string</TwnNm>
          <TwnLctnNm>string</TwnLctnNm>
          <DstrctNm>string</DstrctNm>
          <CtrySubDvsn>string</CtrySubDvsn>
          <Ctry>string</Ctry>
        </PstlAdr>
      </FinInstnId>
    </PrvsInstgAgt2>
    <PrvsInstgAgt2Acct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </PrvsInstgAgt2Acct>
    <PrvsInstgAgt3>
      <FinInstnId>
        <BICFI>string</BICFI>
        <ClrSysMmbId>
          <ClrSysId>
            <Cd>string</Cd>
          </ClrSysId>
          <MmbId>string</MmbId>
        </ClrSysMmbId>
        <LEI>string</LEI>
        <Nm>string</Nm>
        <PstlAdr>
          <Dept>string</Dept>
          <SubDept>string</SubDept>
          <StrtNm>string</StrtNm>
          <BldgNb>string</BldgNb>
          <BldgNm>string</BldgNm>
          <Flr>string</Flr>
          <PstBx>string</PstBx>
          <Room>string</Room>
          <PstCd>string</PstCd>
          <TwnNm>string</TwnNm>
          <TwnLctnNm>string</TwnLctnNm>
          <DstrctNm>string</DstrctNm>
          <CtrySubDvsn>string</CtrySubDvsn>
          <Ctry>string</Ctry>
        </PstlAdr>
      </FinInstnId>
    </PrvsInstgAgt3>
    <PrvsInstgAgt3Acct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </PrvsInstgAgt3Acct>
    <InstgAgt>
      <FinInstnId>
        <BICFI>string</BICFI>
        <LEI>string</LEI>
      </FinInstnId>
    </InstgAgt>
    <InstdAgt>
      <FinInstnId>
        <BICFI>string</BICFI>
        <LEI>string</LEI>
      </FinInstnId>
    </InstdAgt>
    <IntrmyAgt1>
      <FinInstnId>
        <BICFI>string</BICFI>
        <ClrSysMmbId>
          <ClrSysId>
            <Cd>string</Cd>
          </ClrSysId>
          <MmbId>string</MmbId>
        </ClrSysMmbId>
        <LEI>string</LEI>
        <Nm>string</Nm>
        <PstlAdr>
          <Dept>string</Dept>
          <SubDept>string</SubDept>
          <StrtNm>string</StrtNm>
          <BldgNb>string</BldgNb>
          <BldgNm>string</BldgNm>
          <Flr>string</Flr>
          <PstBx>string</PstBx>
          <Room>string</Room>
          <PstCd>string</PstCd>
          <TwnNm>string</TwnNm>
          <TwnLctnNm>string</TwnLctnNm>
          <DstrctNm>string</DstrctNm>
          <CtrySubDvsn>string</CtrySubDvsn>
          <Ctry>string</Ctry>
          <AdrLine>string</AdrLine>
        </PstlAdr>
      </FinInstnId>
    </IntrmyAgt1>
    <IntrmyAgt1Acct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </IntrmyAgt1Acct>
    <IntrmyAgt2>
      <FinInstnId>
        <BICFI>string</BICFI>
        <LEI>string</LEI>
      </FinInstnId>
    </IntrmyAgt2>
    <IntrmyAgt2Acct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </IntrmyAgt2Acct>
    <IntrmyAgt3>
      <FinInstnId>
        <BICFI>string</BICFI>
        <LEI>string</LEI>
      </FinInstnId>
    </IntrmyAgt3>
    <IntrmyAgt3Acct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </IntrmyAgt3Acct>
    <UltmtDbtr>
      <Nm>string</Nm>
      <PstlAdr>
        <Dept>string</Dept>
        <SubDept>string</SubDept>
        <StrtNm>string</StrtNm>
        <BldgNb>string</BldgNb>
        <BldgNm>string</BldgNm>
        <Flr>string</Flr>
        <PstBx>string</PstBx>
        <Room>string</Room>
        <PstCd>string</PstCd>
        <TwnNm>string</TwnNm>
        <TwnLctnNm>string</TwnLctnNm>
        <DstrctNm>string</DstrctNm>
        <CtrySubDvsn>string</CtrySubDvsn>
        <Ctry>string</Ctry>
      </PstlAdr>
      <Id>
        <PrvtId>
          <DtAndPlcOfBirth>
            <BirthDt>2021-05-24</BirthDt>
            <PrvcOfBirth>2342342342342342342342342</PrvcOfBirth>
            <CityOfBirth>2342342342342342342342</CityOfBirth>
            <CtryOfBirth>23423423423423423423423</CtryOfBirth>
          </DtAndPlcOfBirth>
          <Othr>
            <Id>string</Id>
            <SchmeNm>
              <Cd>string</Cd>
            </SchmeNm>
            <Issr>string</Issr>
          </Othr>
        </PrvtId>
      </Id>
      <CtryOfRes>string</CtryOfRes>
    </UltmtDbtr>
    <InitgPty>
      <Nm>string</Nm>
      <PstlAdr>
        <Dept>string</Dept>
        <SubDept>string</SubDept>
        <StrtNm>string</StrtNm>
        <BldgNb>string</BldgNb>
        <BldgNm>string</BldgNm>
        <Flr>string</Flr>
        <PstBx>string</PstBx>
        <Room>string</Room>
        <PstCd>string</PstCd>
        <TwnNm>string</TwnNm>
        <TwnLctnNm>string</TwnLctnNm>
        <DstrctNm>string</DstrctNm>
        <CtrySubDvsn>string</CtrySubDvsn>
        <Ctry>string</Ctry>
      </PstlAdr>
      <Id>
        <PrvtId>
          <DtAndPlcOfBirth>
            <BirthDt>2021-05-24</BirthDt>
            <PrvcOfBirth>2343242342342342342</PrvcOfBirth>
            <CityOfBirth>2342342342342342342</CityOfBirth>
            <CtryOfBirth>2343242342342342</CtryOfBirth>
          </DtAndPlcOfBirth>
          <Othr>
            <Id>string</Id>
            <SchmeNm>
              <Cd>string</Cd>
            </SchmeNm>
            <Issr>string</Issr>
          </Othr>
        </PrvtId>
      </Id>
      <CtryOfRes>string</CtryOfRes>
    </InitgPty>
    <Dbtr>
      <Nm>string</Nm>
      <PstlAdr>
        <Dept>string</Dept>
        <SubDept>string</SubDept>
        <StrtNm>string</StrtNm>
        <BldgNb>string</BldgNb>
        <BldgNm>string</BldgNm>
        <Flr>string</Flr>
        <PstBx>string</PstBx>
        <Room>string</Room>
        <PstCd>string</PstCd>
        <TwnNm>string</TwnNm>
        <TwnLctnNm>string</TwnLctnNm>
        <DstrctNm>string</DstrctNm>
        <CtrySubDvsn>string</CtrySubDvsn>
        <Ctry>string</Ctry>
        <AdrLine>string</AdrLine>
      </PstlAdr>
      <Id />
      <CtryOfRes>string</CtryOfRes>
      <CtctDtls>
        <Nm>string</Nm>
        <PhneNb>string</PhneNb>
        <MobNb>string</MobNb>
        <FaxNb>string</FaxNb>
        <EmailAdr>string</EmailAdr>
      </CtctDtls>
    </Dbtr>
    <DbtrAcct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </DbtrAcct>
    <DbtrAgt>
      <FinInstnId>
        <BICFI>string</BICFI>
        <ClrSysMmbId>
          <ClrSysId>
            <Cd>string</Cd>
          </ClrSysId>
          <MmbId>string</MmbId>
        </ClrSysMmbId>
        <LEI>string</LEI>
        <Nm>string</Nm>
        <PstlAdr>
          <Dept>string</Dept>
          <SubDept>string</SubDept>
          <StrtNm>string</StrtNm>
          <BldgNb>string</BldgNb>
          <BldgNm>string</BldgNm>
          <Flr>string</Flr>
          <PstBx>string</PstBx>
          <Room>string</Room>
          <PstCd>string</PstCd>
          <TwnNm>string</TwnNm>
          <TwnLctnNm>string</TwnLctnNm>
          <DstrctNm>string</DstrctNm>
          <CtrySubDvsn>string</CtrySubDvsn>
          <Ctry>string</Ctry>
          <AdrLine>string</AdrLine>
        </PstlAdr>
      </FinInstnId>
    </DbtrAgt>
    <DbtrAgtAcct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </DbtrAgtAcct>
    <CdtrAgt>
      <FinInstnId>
        <BICFI>string</BICFI>
        <ClrSysMmbId>
          <ClrSysId>
            <Cd>string</Cd>
          </ClrSysId>
          <MmbId>string</MmbId>
        </ClrSysMmbId>
        <LEI>string</LEI>
        <Nm>string</Nm>
        <PstlAdr>
          <Dept>string</Dept>
          <SubDept>string</SubDept>
          <StrtNm>string</StrtNm>
          <BldgNb>string</BldgNb>
          <BldgNm>string</BldgNm>
          <Flr>string</Flr>
          <PstBx>string</PstBx>
          <Room>string</Room>
          <PstCd>string</PstCd>
          <TwnNm>string</TwnNm>
          <TwnLctnNm>string</TwnLctnNm>
          <DstrctNm>string</DstrctNm>
          <CtrySubDvsn>string</CtrySubDvsn>
          <Ctry>string</Ctry>
          <AdrLine>string</AdrLine>
        </PstlAdr>
      </FinInstnId>
    </CdtrAgt>
    <CdtrAgtAcct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </CdtrAgtAcct>
    <Cdtr>
      <Nm>string</Nm>
      <PstlAdr>
        <Dept>string</Dept>
        <SubDept>string</SubDept>
        <StrtNm>string</StrtNm>
        <BldgNb>string</BldgNb>
        <BldgNm>string</BldgNm>
        <Flr>string</Flr>
        <PstBx>string</PstBx>
        <Room>string</Room>
        <PstCd>string</PstCd>
        <TwnNm>string</TwnNm>
        <TwnLctnNm>string</TwnLctnNm>
        <DstrctNm>string</DstrctNm>
        <CtrySubDvsn>string</CtrySubDvsn>
        <Ctry>string</Ctry>
        <AdrLine>string</AdrLine>
      </PstlAdr>
      <Id>
        <PrvtId>
          <DtAndPlcOfBirth>
            <BirthDt>2021-05-24</BirthDt>
            <PrvcOfBirth>234234234234234234234</PrvcOfBirth>
            <CityOfBirth>234234234234234234234</CityOfBirth>
            <CtryOfBirth>234234234234234234234</CtryOfBirth>
          </DtAndPlcOfBirth>
          <Othr>
            <Id>string</Id>
            <SchmeNm>
              <Cd>string</Cd>
            </SchmeNm>
            <Issr>string</Issr>
          </Othr>
        </PrvtId>
      </Id>
      <CtryOfRes>string</CtryOfRes>
    </Cdtr>
    <CdtrAcct>
      <Id />
      <Tp>
        <Cd>string</Cd>
      </Tp>
      <Ccy>string</Ccy>
      <Nm>string</Nm>
      <Prxy>
        <Tp>
          <Cd>string</Cd>
        </Tp>
        <Id>string</Id>
      </Prxy>
    </CdtrAcct>
    <UltmtCdtr>
      <Nm>string</Nm>
      <PstlAdr>
        <Dept>string</Dept>
        <SubDept>string</SubDept>
        <StrtNm>string</StrtNm>
        <BldgNb>string</BldgNb>
        <BldgNm>string</BldgNm>
        <Flr>string</Flr>
        <PstBx>string</PstBx>
        <Room>string</Room>
        <PstCd>string</PstCd>
        <TwnNm>string</TwnNm>
        <TwnLctnNm>string</TwnLctnNm>
        <DstrctNm>string</DstrctNm>
        <CtrySubDvsn>string</CtrySubDvsn>
        <Ctry>string</Ctry>
      </PstlAdr>
      <Id>
        <PrvtId>
          <DtAndPlcOfBirth>
            <BirthDt>2021-05-24</BirthDt>
            <PrvcOfBirth>234234234234234234234</PrvcOfBirth>
            <CityOfBirth>234234234234234234234</CityOfBirth>
            <CtryOfBirth>234234234234234234234</CtryOfBirth>
          </DtAndPlcOfBirth>
          <Othr>
            <Id>string</Id>
            <SchmeNm>
              <Cd>string</Cd>
            </SchmeNm>
            <Issr>string</Issr>
          </Othr>
        </PrvtId>
      </Id>
      <CtryOfRes>string</CtryOfRes>
    </UltmtCdtr>
    <InstrForCdtrAgt>
      <Cd>CHQB</Cd>
      <InstrInf>string</InstrInf>
    </InstrForCdtrAgt>
    <InstrForNxtAgt>
      <InstrInf>string</InstrInf>
    </InstrForNxtAgt>
    <Purp>
      <Cd>string</Cd>
    </Purp>
    <RgltryRptg>
      <Authrty>
        <Nm>string</Nm>
        <Ctry>string</Ctry>
      </Authrty>
      <Dtls>
        <Tp>string</Tp>
        <Ctry>string</Ctry>
        <Cd>string</Cd>
        <Amt Ccy='string'>0</Amt>
        <Inf>string</Inf>
      </Dtls>
    </RgltryRptg>
    <RltdRmtInf>
      <RmtId>string</RmtId>
      <RmtLctnDtls>
        <Mtd>FAXI</Mtd>
        <ElctrncAdr>string</ElctrncAdr>
        <PstlAdr>
          <Nm>string</Nm>
          <Adr>
            <Dept>string</Dept>
            <SubDept>string</SubDept>
            <StrtNm>string</StrtNm>
            <BldgNb>string</BldgNb>
            <BldgNm>string</BldgNm>
            <Flr>string</Flr>
            <PstBx>string</PstBx>
            <Room>string</Room>
            <PstCd>string</PstCd>
            <TwnNm>string</TwnNm>
            <TwnLctnNm>string</TwnLctnNm>
            <DstrctNm>string</DstrctNm>
            <CtrySubDvsn>string</CtrySubDvsn>
            <Ctry>string</Ctry>
          </Adr>
        </PstlAdr>
      </RmtLctnDtls>
    </RltdRmtInf>
    <RmtInf>
      <Ustrd>string</Ustrd>
      <Strd>
        <RfrdDocInf>
          <Tp>
            <CdOrPrtry>
              <Prtry>string</Prtry>
            </CdOrPrtry>
            <Issr>string</Issr>
          </Tp>
          <Nb>string</Nb>
          <LineDtls>
            <Id>
              <Tp>
                <CdOrPrtry>
                  <Cd>string</Cd>
                </CdOrPrtry>
                <Issr>string</Issr>
              </Tp>
              <Nb>string</Nb>
            </Id>
            <Desc>string</Desc>
            <Amt>
              <DuePyblAmt Ccy='string'>0</DuePyblAmt>
              <DscntApldAmt>
                <Tp>
                  <Cd>string</Cd>
                </Tp>
                <Amt Ccy='string'>0</Amt>
              </DscntApldAmt>
              <CdtNoteAmt Ccy='string'>0</CdtNoteAmt>
              <TaxAmt>
                <Tp>
                  <Cd>string</Cd>
                </Tp>
                <Amt Ccy='string'>0</Amt>
              </TaxAmt>
              <AdjstmntAmtAndRsn>
                <Amt Ccy='string'>0</Amt>
                <Rsn>string</Rsn>
                <AddtlInf>string</AddtlInf>
              </AdjstmntAmtAndRsn>
              <RmtdAmt Ccy='string'>0</RmtdAmt>
            </Amt>
          </LineDtls>
        </RfrdDocInf>
        <RfrdDocAmt>
          <DuePyblAmt Ccy='string'>0</DuePyblAmt>
          <DscntApldAmt>
            <Tp>
              <Cd>string</Cd>
            </Tp>
            <Amt Ccy='string'>0</Amt>
          </DscntApldAmt>
          <CdtNoteAmt Ccy='string'>0</CdtNoteAmt>
          <TaxAmt>
            <Tp>
              <Cd>string</Cd>
            </Tp>
            <Amt Ccy='string'>0</Amt>
          </TaxAmt>
          <AdjstmntAmtAndRsn>
            <Amt Ccy='string'>0</Amt>
            <Rsn>string</Rsn>
            <AddtlInf>string</AddtlInf>
          </AdjstmntAmtAndRsn>
          <RmtdAmt Ccy='string'>0</RmtdAmt>
        </RfrdDocAmt>
        <CdtrRefInf>
          <Tp>
            <CdOrPrtry>
              <Prtry>string</Prtry>
            </CdOrPrtry>
            <Issr>string</Issr>
          </Tp>
          <Ref>string</Ref>
        </CdtrRefInf>
        <Invcr>
          <Nm>string</Nm>
          <PstlAdr>
            <Dept>string</Dept>
            <SubDept>string</SubDept>
            <StrtNm>string</StrtNm>
            <BldgNb>string</BldgNb>
            <BldgNm>string</BldgNm>
            <Flr>string</Flr>
            <PstBx>string</PstBx>
            <Room>string</Room>
            <PstCd>string</PstCd>
            <TwnNm>string</TwnNm>
            <TwnLctnNm>string</TwnLctnNm>
            <DstrctNm>string</DstrctNm>
            <CtrySubDvsn>string</CtrySubDvsn>
            <Ctry>string</Ctry>
          </PstlAdr>
          <Id />
          <CtryOfRes>string</CtryOfRes>
        </Invcr>
        <Invcee>
          <Nm>string</Nm>
          <PstlAdr>
            <Dept>string</Dept>
            <SubDept>string</SubDept>
            <StrtNm>string</StrtNm>
            <BldgNb>string</BldgNb>
            <BldgNm>string</BldgNm>
            <Flr>string</Flr>
            <PstBx>string</PstBx>
            <Room>string</Room>
            <PstCd>string</PstCd>
            <TwnNm>string</TwnNm>
            <TwnLctnNm>string</TwnLctnNm>
            <DstrctNm>string</DstrctNm>
            <CtrySubDvsn>string</CtrySubDvsn>
            <Ctry>string</Ctry>
          </PstlAdr>
          <Id />
          <CtryOfRes>string</CtryOfRes>
        </Invcee>
        <TaxRmt>
          <Cdtr>
            <TaxId>string</TaxId>
            <RegnId>string</RegnId>
            <TaxTp>string</TaxTp>
          </Cdtr>
          <Dbtr>
            <TaxId>string</TaxId>
            <RegnId>string</RegnId>
            <TaxTp>string</TaxTp>
            <Authstn>
              <Titl>string</Titl>
              <Nm>string</Nm>
            </Authstn>
          </Dbtr>
          <UltmtDbtr>
            <TaxId>string</TaxId>
            <RegnId>string</RegnId>
            <TaxTp>string</TaxTp>
            <Authstn>
              <Titl>string</Titl>
              <Nm>string</Nm>
            </Authstn>
          </UltmtDbtr>
          <AdmstnZone>string</AdmstnZone>
          <RefNb>string</RefNb>
          <Mtd>string</Mtd>
          <TtlTaxblBaseAmt Ccy='string'>0</TtlTaxblBaseAmt>
          <TtlTaxAmt Ccy='string'>0</TtlTaxAmt>
          <Rcrd>
            <Tp>string</Tp>
            <Ctgy>string</Ctgy>
            <CtgyDtls>string</CtgyDtls>
            <DbtrSts>string</DbtrSts>
            <CertId>string</CertId>
            <FrmsCd>string</FrmsCd>
            <Prd>
              <FrToDt>
                <FrDt>2021-05-24</FrDt>
                <ToDt>2021-05-24</ToDt>
              </FrToDt>
            </Prd>
            <TaxAmt>
              <TaxblBaseAmt Ccy='string'>0</TaxblBaseAmt>
              <TtlAmt Ccy='string'>0</TtlAmt>
              <Dtls>
                <Prd>
                  <FrToDt>
                    <FrDt>2021-05-24</FrDt>
                    <ToDt>2021-05-24</ToDt>
                  </FrToDt>
                </Prd>
                <Amt Ccy='string'>0</Amt>
              </Dtls>
            </TaxAmt>
            <AddtlInf>string</AddtlInf>
          </Rcrd>
        </TaxRmt>
        <GrnshmtRmt>
          <Tp>
            <CdOrPrtry>
              <Cd>string</Cd>
            </CdOrPrtry>
            <Issr>string</Issr>
          </Tp>
          <Grnshee>
            <Nm>string</Nm>
            <PstlAdr>
              <Dept>string</Dept>
              <SubDept>string</SubDept>
              <StrtNm>string</StrtNm>
              <BldgNb>string</BldgNb>
              <BldgNm>string</BldgNm>
              <Flr>string</Flr>
              <PstBx>string</PstBx>
              <Room>string</Room>
              <PstCd>string</PstCd>
              <TwnNm>string</TwnNm>
              <TwnLctnNm>string</TwnLctnNm>
              <DstrctNm>string</DstrctNm>
              <CtrySubDvsn>string</CtrySubDvsn>
              <Ctry>string</Ctry>
            </PstlAdr>
            <Id />
            <CtryOfRes>string</CtryOfRes>
          </Grnshee>
          <GrnshmtAdmstr>
            <Nm>string</Nm>
            <PstlAdr>
              <Dept>string</Dept>
              <SubDept>string</SubDept>
              <StrtNm>string</StrtNm>
              <BldgNb>string</BldgNb>
              <BldgNm>string</BldgNm>
              <Flr>string</Flr>
              <PstBx>string</PstBx>
              <Room>string</Room>
              <PstCd>string</PstCd>
              <TwnNm>string</TwnNm>
              <TwnLctnNm>string</TwnLctnNm>
              <DstrctNm>string</DstrctNm>
              <CtrySubDvsn>string</CtrySubDvsn>
              <Ctry>string</Ctry>
            </PstlAdr>
            <Id />
            <CtryOfRes>string</CtryOfRes>
          </GrnshmtAdmstr>
          <RefNb>string</RefNb>
          <RmtdAmt Ccy='string'>0</RmtdAmt>
          <FmlyMdclInsrncInd>true</FmlyMdclInsrncInd>
          <MplyeeTermntnInd>true</MplyeeTermntnInd>
        </GrnshmtRmt>
        <AddtlRmtInf>string</AddtlRmtInf>
      </Strd>
    </RmtInf>
  </CdtTrfTxInf>
</FIToFICustomerCreditTransferV08>";
    }

    public static class Xsd
    {
        public static readonly string XmlText = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<xs:schema xmlns=""urn:iso:std:iso:20022:tech:xsd:pacs.008.001.08"" xmlns:xs=""http://www.w3.org/2001/XMLSchema"" elementFormDefault=""qualified"" targetNamespace=""urn:iso:std:iso:20022:tech:xsd:pacs.008.001.08"">
    <xs:element name=""Document"" type=""Document""/>
    <xs:complexType name=""AccountIdentification4Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">AccountIdentification4Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the unique identification of an account as assigned by the account servicer.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""IBAN"" type=""IBAN2007Identifier"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">IBAN</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">International Bank Account Number (IBAN) - identifier used internationally by financial institutions to uniquely identify the account of a customer. Further specifications of the format and content of the IBAN can be found in the standard ISO 13616 ""Banking and related financial services - International Bank Account Number (IBAN)"" version 1997-10-01, or later revisions.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Othr"" type=""GenericAccountIdentification1__1"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Other</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification of an account, as assigned by the account servicer, using an identification scheme.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""AccountSchemeName1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">AccountSchemeName1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Sets of elements to identify a name of the identification scheme.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalAccountIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""ActiveCurrencyCode"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ActiveCurrencyCode</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">A code allocated to a currency by a Maintenance Agency under an international identification scheme as described in the latest edition of the international standard ISO 4217 ""Codes for the representation of currencies and funds"".</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[A-Z]{3,3}""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ActiveOrHistoricCurrencyAndAmount__1_SimpleType"">
        <xs:restriction base=""xs:decimal"">
            <xs:fractionDigits value=""5""/>
            <xs:totalDigits value=""18""/>
            <xs:minInclusive value=""0""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""ActiveOrHistoricCurrencyAndAmount__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ActiveOrHistoricCurrencyAndAmount__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">A number of monetary units specified in an active or a historic currency where the unit of currency is explicit and compliant with ISO 4217.</xs:documentation>
        </xs:annotation>
        <xs:simpleContent>
            <xs:extension base=""ActiveOrHistoricCurrencyAndAmount__1_SimpleType"">
                <xs:attribute name=""Ccy"" type=""ActiveCurrencyCode"" use=""required"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Currency</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Medium of exchange of currency.</xs:documentation>
                    </xs:annotation>
                </xs:attribute>
            </xs:extension>
        </xs:simpleContent>
    </xs:complexType>
    <xs:simpleType name=""BaseOneRate"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BaseOneRate</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Rate expressed as a decimal, for example, 0.7 is 7/10 and 70%.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:decimal"">
            <xs:fractionDigits value=""10""/>
            <xs:totalDigits value=""11""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""BranchAndFinancialInstitutionIdentification6__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BranchAndFinancialInstitutionIdentification6__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution or a branch of a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""FinInstnId"" type=""FinancialInstitutionIdentification18__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution, as assigned under an internationally recognised or proprietary identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""BranchAndFinancialInstitutionIdentification6__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BranchAndFinancialInstitutionIdentification6__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution or a branch of a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""FinInstnId"" type=""FinancialInstitutionIdentification18__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution, as assigned under an internationally recognised or proprietary identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""BranchAndFinancialInstitutionIdentification6__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BranchAndFinancialInstitutionIdentification6__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution or a branch of a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""FinInstnId"" type=""FinancialInstitutionIdentification18__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution, as assigned under an internationally recognised or proprietary identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""BranchAndFinancialInstitutionIdentification6__4"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BranchAndFinancialInstitutionIdentification6__4</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution or a branch of a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""FinInstnId"" type=""FinancialInstitutionIdentification18__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution, as assigned under an internationally recognised or proprietary identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""BranchAndFinancialInstitutionIdentification6__5"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BranchAndFinancialInstitutionIdentification6__5</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution or a branch of a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""FinInstnId"" type=""FinancialInstitutionIdentification18__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a financial institution, as assigned under an internationally recognised or proprietary identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BrnchId"" type=""BranchData3__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BranchIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a specific branch of a financial institution.

Usage: This component should be used in case the identification information in the financial institution component does not provide identification up to branch level.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""BranchData3__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">BranchData3__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific branch of a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Id"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a branch of a financial institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CashAccount38__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CashAccount38__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides the details to identify an account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""AccountIdentification4Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification for the account between the account owner and the account servicer.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""CashAccountType2Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the nature, or use of the account.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ccy"" type=""ActiveCurrencyCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Currency</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the currency in which the account is held. 

Usage: Currency should only be used in case one and the same account number covers several currencies
and the initiating party needs to identify which currency needs to be used for settlement on the account.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the account, as assigned by the account servicing institution, in agreement with the account owner in order to provide an additional means of identification of the account.

Usage: The account name is different from the account owner name. The account name is used in certain user communities to provide a means of identifying the account, in addition to the account owner's identity and the account number.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Prxy"" type=""ProxyAccountIdentification1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Proxy</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies an alternate assumed name for the identification of the account. </xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CashAccount38__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CashAccount38__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides the details to identify an account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""AccountIdentification4Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification for the account between the account owner and the account servicer.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""CashAccountType2Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the nature, or use of the account.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ccy"" type=""ActiveCurrencyCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Currency</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the currency in which the account is held. 

Usage: Currency should only be used in case one and the same account number covers several currencies
and the initiating party needs to identify which currency needs to be used for settlement on the account.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the account, as assigned by the account servicing institution, in agreement with the account owner in order to provide an additional means of identification of the account.

Usage: The account name is different from the account owner name. The account name is used in certain user communities to provide a means of identifying the account, in addition to the account owner's identity and the account number.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Prxy"" type=""ProxyAccountIdentification1__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Proxy</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies an alternate assumed name for the identification of the account. </xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CashAccountType2Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CashAccountType2Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Nature or use of the account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalCashAccountType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Account type, in a coded form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Nature or use of the account in a proprietary form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CategoryPurpose1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CategoryPurpose1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the high level purpose of the instruction based on a set of pre-defined categories.
Usage: This is used by the initiating party to provide information concerning the processing of the payment. It is likely to trigger special processing by any of the agents involved in the payment chain.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalCategoryPurpose1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Category purpose, as published in an external category purpose code list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Category purpose, in a proprietary form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""ChargeBearerType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ChargeBearerType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies which party(ies) will pay charges due for processing of the instruction.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""DEBT"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BorneByDebtor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">All transaction charges are to be borne by the debtor.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""CRED"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BorneByCreditor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">All transaction charges are to be borne by the creditor.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""SHAR"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Shared</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">In a credit transfer context, means that transaction charges on the sender side are to be borne by the debtor, transaction charges on the receiver side are to be borne by the creditor. In a direct debit context, means that transaction charges on the sender side are to be borne by the creditor, transaction charges on the receiver side are to be borne by the debtor.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""SLEV"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FollowingServiceLevel</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Charges are to be applied following the rules agreed in the service level and/or scheme.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""Charges7__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Charges7__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the charges related to the payment transaction.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Amt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Transaction charges to be paid by the charge bearer.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Agt"" type=""BranchAndFinancialInstitutionIdentification6__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Agent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent that takes the transaction charges or to which the transaction charges are due.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ClearingSystemIdentification2Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemIdentification2Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Choice of a clearing system identifier.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalClearingSystemIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a clearing system, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ClearingSystemIdentification3Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemIdentification3Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the clearing system identification.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalCashClearingSystem1Code_fixed"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Infrastructure through which the payment instruction is processed, as published in an external clearing system identification code list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ClearingSystemMemberIdentification2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemMemberIdentification2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification, as assigned by a clearing system, to unambiguously identify a member of the clearing system.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""ClrSysId"" type=""ClearingSystemIdentification2Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""MmbId"" type=""TARGET_RestrictedFINXMax28Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">MemberIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a member of a clearing system.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Contact4__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Contact4__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the details of the contact person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which a party is known and which is usually used to identify that party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PhneNb"" type=""TARGET_RestrictedFINXMax30Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PhoneNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Collection of information that identifies a phone number, as defined by telecom services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""MobNb"" type=""TARGET_RestrictedFINXMax30Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">MobileNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Collection of information that identifies a mobile phone number, as defined by telecom services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""FaxNb"" type=""TARGET_RestrictedFINXMax30Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FaxNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Collection of information that identifies a FAX number, as defined by telecom services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""EmailAdr"" type=""TARGET_RestrictedFINXMax320Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">EmailAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Address for electronic mail (e-mail).</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""CountryCode"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CountryCode</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Code to identify a country, a dependency, or another area of particular geopolitical interest, on the basis of country names obtained from the United Nations (ISO 3166, Alpha-2 code).</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[A-Z]{2,2}""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""CreditDebitCode"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CreditDebitCode</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies if an operation is an increase or a decrease.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""CRDT"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Credit</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Operation is an increase.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""DBIT"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Debit</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Operation is a decrease.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""CreditTransferTransaction39__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CreditTransferTransaction39__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides further details specific to the individual transaction(s) included in the message.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""PmtId"" type=""PaymentIdentification7__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PaymentIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to reference a payment instruction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PmtTpInf"" type=""PaymentTypeInformation28__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PaymentTypeInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to further specify the type of transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""IntrBkSttlmAmt"" type=""TARGET_Max18_Max2DecimalAmount"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InterbankSettlementAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money moved between the instructing agent and the instructed agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""IntrBkSttlmDt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InterbankSettlementDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date on which the amount of money ceases to be available to the agent that owes it and when the amount of money becomes available to the agent to which it is due.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SttlmPrty"" type=""Priority3Code__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SettlementPriority</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Indicator of the urgency or order of importance that the instructing party would like the instructed party to apply to the processing of the settlement instruction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SttlmTmIndctn"" type=""SettlementDateTimeIndication1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SettlementTimeIndication</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the occurred settlement time(s) of the payment transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SttlmTmReq"" type=""SettlementTimeRequest2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SettlementTimeRequest</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the requested settlement time(s) of the payment instruction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""InstdAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructedAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money to be moved between the debtor and creditor, before deduction of charges, expressed in the currency as ordered by the initiating party.&#13;
Usage: This amount has to be transported unchanged through the transaction chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""XchgRate"" type=""BaseOneRate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ExchangeRate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Factor used to convert an amount from one currency into another. This reflects the price at which one currency was bought with another currency.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""ChrgBr"" type=""ChargeBearerType1Code"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ChargeBearer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies which party/parties will bear the charges associated with the processing of the payment transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""ChrgsInf"" type=""Charges7__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ChargesInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the charges to be paid by the charge bearer(s) related to the payment transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvsInstgAgt1"" type=""BranchAndFinancialInstitutionIdentification6__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PreviousInstructingAgent1</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent immediately prior to the instructing agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvsInstgAgt1Acct"" type=""CashAccount38__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PreviousInstructingAgent1Account</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the previous instructing agent at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvsInstgAgt2"" type=""BranchAndFinancialInstitutionIdentification6__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PreviousInstructingAgent2</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent immediately prior to the instructing agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvsInstgAgt2Acct"" type=""CashAccount38__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PreviousInstructingAgent2Account</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the previous instructing agent at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvsInstgAgt3"" type=""BranchAndFinancialInstitutionIdentification6__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PreviousInstructingAgent3</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent immediately prior to the instructing agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvsInstgAgt3Acct"" type=""CashAccount38__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PreviousInstructingAgent3Account</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the previous instructing agent at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""InstgAgt"" type=""BranchAndFinancialInstitutionIdentification6__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructingAgent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent that instructs the next party in the chain to carry out the (set of) instruction(s).</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""InstdAgt"" type=""BranchAndFinancialInstitutionIdentification6__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructedAgent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent that is instructed by the previous party in the chain to carry out the (set of) instruction(s).</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""IntrmyAgt1"" type=""BranchAndFinancialInstitutionIdentification6__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">IntermediaryAgent1</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent between the debtor's agent and the creditor's agent.

Usage: If more than one intermediary agent is present, then IntermediaryAgent1 identifies the agent between the DebtorAgent and the IntermediaryAgent2.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""IntrmyAgt1Acct"" type=""CashAccount38__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">IntermediaryAgent1Account</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the intermediary agent 1 at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""IntrmyAgt2"" type=""BranchAndFinancialInstitutionIdentification6__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">IntermediaryAgent2</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent between the debtor's agent and the creditor's agent.

Usage: If more than two intermediary agents are present, then IntermediaryAgent2 identifies the agent between the IntermediaryAgent1 and the IntermediaryAgent3.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""IntrmyAgt2Acct"" type=""CashAccount38__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">IntermediaryAgent2Account</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the intermediary agent 2 at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""IntrmyAgt3"" type=""BranchAndFinancialInstitutionIdentification6__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">IntermediaryAgent3</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agent between the debtor's agent and the creditor's agent.

Usage: If IntermediaryAgent3 is present, then it identifies the agent between the IntermediaryAgent 2 and the CreditorAgent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""IntrmyAgt3Acct"" type=""CashAccount38__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">IntermediaryAgent3Account</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the intermediary agent 3 at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""UltmtDbtr"" type=""PartyIdentification135__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">UltimateDebtor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Ultimate party that owes an amount of money to the (ultimate) creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""InitgPty"" type=""PartyIdentification135__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InitiatingParty</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Party that initiates the payment.
Usage: This can be either the debtor or a party that initiates the credit transfer on behalf of the debtor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Dbtr"" type=""PartyIdentification135__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Debtor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Party that owes an amount of money to the (ultimate) creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DbtrAcct"" type=""CashAccount38__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebtorAccount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the debtor to which a debit entry will be made as a result of the transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""DbtrAgt"" type=""BranchAndFinancialInstitutionIdentification6__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebtorAgent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Financial institution servicing an account for the debtor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DbtrAgtAcct"" type=""CashAccount38__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebtorAgentAccount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the debtor agent at its servicing agent in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""CdtrAgt"" type=""BranchAndFinancialInstitutionIdentification6__5"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditorAgent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Financial institution servicing an account for the creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CdtrAgtAcct"" type=""CashAccount38__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditorAgentAccount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the creditor agent at its servicing agent to which a credit entry will be made as a result of the payment transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Cdtr"" type=""PartyIdentification135__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Creditor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Party to which an amount of money is due.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CdtrAcct"" type=""CashAccount38__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditorAccount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unambiguous identification of the account of the creditor to which a credit entry will be posted as a result of the payment transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""UltmtCdtr"" type=""PartyIdentification135__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">UltimateCreditor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Ultimate party to which an amount of money is due.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""2"" minOccurs=""0"" name=""InstrForCdtrAgt"" type=""InstructionForCreditorAgent1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructionForCreditorAgent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Further information related to the processing of the payment instruction, provided by the initiating party, and intended for the creditor agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""6"" minOccurs=""0"" name=""InstrForNxtAgt"" type=""InstructionForNextAgent1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructionForNextAgent</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Further information related to the processing of the payment instruction that may need to be acted upon by the next agent. 

Usage: The next agent may not be the creditor agent.
The instruction can relate to a level of service, can be an instruction that has to be executed by the agent, or can be information required by the next agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Purp"" type=""Purpose2Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Purpose</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Underlying reason for the payment transaction.
Usage: Purpose is used by the end-customers, that is initiating party, (ultimate) debtor, (ultimate) creditor to provide information concerning the nature of the payment. Purpose is a content element, which is not used for processing by any of the agents involved in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""10"" minOccurs=""0"" name=""RgltryRptg"" type=""RegulatoryReporting3__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RegulatoryReporting</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information needed due to regulatory and statutory requirements.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RltdRmtInf"" type=""RemittanceLocation7__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RelatedRemittanceInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information related to the handling of the remittance information by any of the agents in the transaction processing chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RmtInf"" type=""RemittanceInformation16__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information supplied to enable the matching of an entry with the items that the transfer is intended to settle, such as commercial invoices in an accounts' receivable system.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CreditorReferenceInformation2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CreditorReferenceInformation2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Reference information provided by the creditor to allow the identification of the underlying documents.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""CreditorReferenceType2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of creditor reference.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ref"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Reference</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique reference, as assigned by the creditor, to unambiguously refer to the payment transaction.

Usage: If available, the initiating party should provide this reference in the structured remittance information, to enable reconciliation by the creditor upon receipt of the amount of money.

If the business context requires the use of a creditor reference or a payment remit identification, and only one identifier can be passed through the end-to-end chain, the creditor's reference or payment remittance identification should be quoted in the end-to-end transaction identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CreditorReferenceType1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CreditorReferenceType1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of document referred by the creditor.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""DocumentType3Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Type of creditor reference, in a coded form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Creditor reference type, in a proprietary form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""CreditorReferenceType2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">CreditorReferenceType2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of creditor reference.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""CdOrPrtry"" type=""CreditorReferenceType1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CodeOrProprietary</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Coded or proprietary format creditor reference type.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the credit reference type.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DateAndPlaceOfBirth1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DateAndPlaceOfBirth1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Date and place of birth of a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""BirthDt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BirthDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date on which a person is born.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PrvcOfBirth"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ProvinceOfBirth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Province where a person was born.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""CityOfBirth"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CityOfBirth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">City where a person was born.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""CtryOfBirth"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountryOfBirth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country where a person was born.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DatePeriod2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DatePeriod2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Range of time defined by a start date and an end date.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""FrDt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FromDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Start date of the range.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""ToDt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ToDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">End date of the range.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DiscountAmountAndType1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DiscountAmountAndType1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount with a specific type.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""DiscountAmountType1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the amount.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Amt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money, which has been typed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DiscountAmountType1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DiscountAmountType1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount type.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalDiscountAmountType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount type, in a coded form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount type, in a free-text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Document"">
        <xs:sequence>
            <xs:element name=""FIToFICstmrCdtTrf"" type=""FIToFICustomerCreditTransferV08""/>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DocumentAdjustment1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentAdjustment1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide information on the amount and reason of the document adjustment.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Amt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money of the document adjustment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CdtDbtInd"" type=""CreditDebitCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditDebitIndicator</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies whether the adjustment must be subtracted or added to the total amount.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Rsn"" type=""TARGET_RestrictedFINXMax4Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Reason</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the reason for the adjustment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""AddtlInf"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AdditionalInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides further details on the document adjustment.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DocumentLineIdentification1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentLineIdentification1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies the documents referred to in the remittance information.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""DocumentLineType1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of referred document line identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nb"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Number</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the type specified for the referred document line.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RltdDt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RelatedDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date associated with the referred document line.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DocumentLineInformation1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentLineInformation1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides document line information.&#13;
</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""unbounded"" minOccurs=""1"" name=""Id"" type=""DocumentLineIdentification1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides identification of the document line.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Desc"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Description</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Description associated with the document line.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Amt"" type=""RemittanceAmount3__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides details on the amounts of the document line.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DocumentLineType1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentLineType1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the document line identification.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalDocumentLineType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Line identification type in a coded form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Proprietary identification of the type of the remittance document.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""DocumentLineType1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentLineType1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the document line identification.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""CdOrPrtry"" type=""DocumentLineType1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CodeOrProprietary</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides the type details of the referred document line identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the issuer of the reference document line identificationtype.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""DocumentType3Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentType3Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a type of financial or commercial document.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""RADM"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceAdviceMessage</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a remittance advice sent separately from the current transaction.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""RPIN"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RelatedPaymentInstruction</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a linked payment instruction to which the current payment instruction is related, for example, in a cover scenario.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""FXDR"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ForeignExchangeDealReference</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a pre-agreed or pre-arranged foreign exchange transaction to which the payment transaction refers.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""DISP"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DispatchAdvice</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a dispatch advice.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""PUOR"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PurchaseOrder</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a purchase order.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""SCOR"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">StructuredCommunicationReference</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a structured communication reference provided by the creditor to identify the referred transaction.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""DocumentType6Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">DocumentType6Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a type of financial or commercial document.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""MSIN"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">MeteredServiceInvoice</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is an invoice claiming payment for the supply of metered services, for example gas or electricity supplied to a fixed meter.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""CNFA"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditNoteRelatedToFinancialAdjustment</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a credit note for the final amount settled for a commercial transaction.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""DNFA"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebitNoteRelatedToFinancialAdjustment</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a debit note for the final amount settled for a commercial transaction.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""CINV"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CommercialInvoice</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is an invoice.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""CREN"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditNote</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a credit note.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""DEBN"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebitNote</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a debit note.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""HIRI"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">HireInvoice</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is an invoice for the hiring of human resources or renting goods or equipment.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""SBIN"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SelfBilledInvoice</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is an invoice issued by the debtor.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""CMCN"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CommercialContract</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is an agreement between the parties, stipulating the terms and conditions of the delivery of goods or services.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""SOAC"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">StatementOfAccount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a statement of the transactions posted to the debtor's account at the supplier.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""DISP"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DispatchAdvice</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a dispatch advice.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""BOLD"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BillOfLading</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a shipping notice.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""VCHR"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Voucher</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is an electronic payment document.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""AROI"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AccountReceivableOpenItem</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a payment that applies to a specific source document.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""TSUT"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TradeServicesUtilityTransaction</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a transaction identifier as assigned by the Trade Services Utility.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""PUOR"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PurchaseOrder</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Document is a purchase order.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalAccountIdentification1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalAccountIdentification1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external account identification scheme name code in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalCashAccountType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalCashAccountType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the nature, or use, of the cash account in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalCashClearingSystem1Code_fixed"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalCashClearingSystem1Code_fixed</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""TGT"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TGT</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalCategoryPurpose1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalCategoryPurpose1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the category purpose, as published in an external category purpose code list.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalClearingSystemIdentification1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalClearingSystemIdentification1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the clearing system identification code, as published in an external clearing system identification code list.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""5""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalDiscountAmountType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalDiscountAmountType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the nature, or use, of the amount in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalDocumentLineType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalDocumentLineType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the document line type as published in an external document type code list.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalGarnishmentType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalGarnishmentType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the garnishment type as published in an external document type code list.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalLocalInstrument1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalLocalInstrument1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external local instrument code in the format of character string with a maximum length of 35 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""35""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalOrganisationIdentification1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalOrganisationIdentification1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external organisation identification scheme name code in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalPersonIdentification1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalPersonIdentification1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external person identification scheme name code in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalProxyAccountType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalProxyAccountType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external proxy account type code, as published in the proxy account type external code set.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalPurpose1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalPurpose1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external purpose code in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalServiceLevel1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalServiceLevel1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the external service level code in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ExternalTaxAmountType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ExternalTaxAmountType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the nature, or use, of the amount in the format of character string with a maximum length of 4 characters.&#13;
The list of valid codes is an external code list published separately.&#13;
External code sets can be downloaded from www.iso20022.org.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""FIToFICustomerCreditTransferV08"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">FIToFICustomerCreditTransferV08</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Scope&#13;
The FinancialInstitutionToFinancialInstitutionCustomerCreditTransfer message is sent by the debtor agent to the creditor agent, directly or through other agents and/or a payment clearing and settlement system. It is used to move funds from a debtor account to a creditor.&#13;
Usage&#13;
The FIToFICustomerCreditTransfer message is exchanged between agents and can contain one or more customer credit transfer instructions.&#13;
The FIToFICustomerCreditTransfer message does not allow for grouping: a CreditTransferTransactionInformation block must be present for each credit transfer transaction.&#13;
The FIToFICustomerCreditTransfer message can be used in different ways:&#13;
- If the instructing agent and the instructed agent wish to use their direct account relationship in the currency of the transfer then the message contains both the funds for the customer transfer(s) as well as the payment details;&#13;
- If the instructing agent and the instructed agent have no direct account relationship in the currency of the transfer, or do not wish to use their account relationship, then other (reimbursement) agents will be involved to cover for the customer transfer(s). The FIToFICustomerCreditTransfer contains only the payment details and the instructing agent must cover the customer transfer by sending a FinancialInstitutionCreditTransfer to a reimbursement agent. This payment method is called the Cover method;&#13;
- If more than two financial institutions are involved in the payment chain and if the FIToFICustomerCreditTransfer is sent from one financial institution to the next financial institution in the payment chain, then the payment method is called the Serial method.&#13;
The FIToFICustomerCreditTransfer message can be used in domestic and cross-border scenarios.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""GrpHdr"" type=""GroupHeader93__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">GroupHeader</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of characteristics shared by all individual transactions included in the message.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""CdtTrfTxInf"" type=""CreditTransferTransaction39__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditTransferTransactionInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements providing information specific to the individual credit transfer(s).</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""FinancialInstitutionIdentification18__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification18__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the details to identify a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BICFI"" type=""TARGET_BIC11Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BICFI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Code allocated to a financial institution by the ISO 9362 Registration Authority as described in ISO 9362 ""Banking - Banking telecommunication messages - Business identifier code (BIC)"".</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""ClrSysMmbId"" type=""ClearingSystemMemberIdentification2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemMemberIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information used to identify a member within a clearing system.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LEI"" type=""LEIIdentifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LEI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Legal entity identifier of the financial institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which an agent is known and which is usually used to identify that agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""FinancialInstitutionIdentification18__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification18__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the details to identify a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BICFI"" type=""TARGET_BIC11Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BICFI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Code allocated to a financial institution by the ISO 9362 Registration Authority as described in ISO 9362 ""Banking - Banking telecommunication messages - Business identifier code (BIC)"".</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""ClrSysMmbId"" type=""ClearingSystemMemberIdentification2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemMemberIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information used to identify a member within a clearing system.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LEI"" type=""LEIIdentifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LEI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Legal entity identifier of the financial institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which an agent is known and which is usually used to identify that agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""FinancialInstitutionIdentification18__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification18__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the details to identify a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""BICFI"" type=""TARGET_BIC11Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BICFI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Code allocated to a financial institution by the ISO 9362 Registration Authority as described in ISO 9362 ""Banking - Banking telecommunication messages - Business identifier code (BIC)"".</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LEI"" type=""LEIIdentifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LEI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Legal entity identifier of the financial institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""FinancialInstitutionIdentification18__4"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">FinancialInstitutionIdentification18__4</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the details to identify a financial institution.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BICFI"" type=""TARGET_BIC11Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BICFI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Code allocated to a financial institution by the ISO 9362 Registration Authority as described in ISO 9362 ""Banking - Banking telecommunication messages - Business identifier code (BIC)"".</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""ClrSysMmbId"" type=""ClearingSystemMemberIdentification2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemMemberIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information used to identify a member within a clearing system.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LEI"" type=""LEIIdentifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LEI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Legal entity identifier of the financial institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which an agent is known and which is usually used to identify that agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Garnishment3__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Garnishment3__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides remittance information about a payment for garnishment-related purposes.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Tp"" type=""GarnishmentType1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of garnishment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Grnshee"" type=""PartyIdentification135__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Garnishee</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Ultimate party that owes an amount of money to the (ultimate) creditor, in this case, to the garnisher.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""GrnshmtAdmstr"" type=""PartyIdentification135__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">GarnishmentAdministrator</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Party on the credit side of the transaction who administers the garnishment on behalf of the ultimate beneficiary.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RefNb"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ReferenceNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Reference information that is specific to the agency receiving the garnishment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Date</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date of payment which garnishment was taken from.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RmtdAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittedAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money remitted for the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""FmlyMdclInsrncInd"" type=""TrueFalseIndicator"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FamilyMedicalInsuranceIndicator</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Indicates if the person to whom the garnishment applies (that is, the ultimate debtor) has family medical insurance coverage available.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""MplyeeTermntnInd"" type=""TrueFalseIndicator"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">EmployeeTerminationIndicator</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Indicates if the employment of the person to whom the garnishment applies (that is, the ultimate debtor) has been terminated.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GarnishmentType1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GarnishmentType1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of garnishment.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalGarnishmentType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Garnishment type in a coded form.&#13;
Would suggest this to be an External Code List to contain:&#13;
GNCS    Garnishment from a third party payer for Child Support&#13;
GNDP    Garnishment from a Direct Payer for Child Support&#13;
GTPP     Garnishment from a third party payer to taxing agency.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Proprietary identification of the type of garnishment.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GarnishmentType1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GarnishmentType1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of garnishment.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""CdOrPrtry"" type=""GarnishmentType1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CodeOrProprietary</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides the type details of the garnishment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the issuer of the garnishment type.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GenericAccountIdentification1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GenericAccountIdentification1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to a generic account identification.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax34Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification assigned by an institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SchmeNm"" type=""AccountSchemeName1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SchemeName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GenericOrganisationIdentification1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GenericOrganisationIdentification1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to an identification of an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification assigned by an institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SchmeNm"" type=""OrganisationIdentificationSchemeName1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SchemeName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GenericOrganisationIdentification1__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GenericOrganisationIdentification1__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to an identification of an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification assigned by an institution.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SchmeNm"" type=""OrganisationIdentificationSchemeName1Choice__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SchemeName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GenericPersonIdentification1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GenericPersonIdentification1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to an identification of a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a person.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SchmeNm"" type=""PersonIdentificationSchemeName1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SchemeName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GenericPersonIdentification1__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GenericPersonIdentification1__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to an identification of a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a person.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SchmeNm"" type=""PersonIdentificationSchemeName1Choice__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SchemeName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GenericPersonIdentification1__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GenericPersonIdentification1__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to an identification of a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a person.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SchmeNm"" type=""PersonIdentificationSchemeName1Choice__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SchemeName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity that assigns the identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""GroupHeader93__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">GroupHeader93__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Set of characteristics shared by all individual transactions included in the message.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""MsgId"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">MessageIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Point to point reference, as assigned by the instructing party, and sent to the next party in the chain to unambiguously identify the message.
Usage: The instructing party has to make sure that MessageIdentification is unique per instructed party for a pre-agreed period.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""CreDtTm"" type=""TARGET_DateTime"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreationDateTime</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date and time at which the message was created.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""NbOfTxs"" type=""Max15NumericText_fixed"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">NumberOfTransactions</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Number of individual transactions contained in the message.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""SttlmInf"" type=""SettlementInstruction7__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SettlementInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the details on how the settlement of the transaction(s) between the instructing agent and the instructed agent is completed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""IBAN2007Identifier"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">IBAN2007Identifier</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">An identifier used internationally by financial institutions to uniquely identify the account of a customer at a financial institution, as described in the latest edition of the international standard ISO 13616: 2007 - ""Banking and related financial services - International Bank Account Number (IBAN)"".</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[A-Z]{2,2}[0-9]{2,2}[a-zA-Z0-9]{1,30}""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""ISODate"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ISODate</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">A particular point in the progression of time in a calendar year expressed in the YYYY-MM-DD format. This representation is defined in ""XML Schema Part 2: Datatypes Second Edition - W3C Recommendation 28 October 2004"" which is aligned with ISO 8601.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:date""/>
    </xs:simpleType>
    <xs:simpleType name=""Instruction3Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Instruction3Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies further instructions concerning the processing of a payment instruction, provided by the sending clearing agent to the next agent(s).</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""CHQB"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PayCreditorByCheque</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">(Ultimate) creditor must be paid by cheque.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""HOLD"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">HoldCashForCreditor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money must be held for the (ultimate) creditor, who will call. Pay on identification.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""PHOB"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PhoneBeneficiary</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Please advise/contact (ultimate) creditor/claimant by phone.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""TELB"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Telecom</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Please advise/contact (ultimate) creditor/claimant by the most efficient means of telecommunication.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""InstructionForCreditorAgent1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">InstructionForCreditorAgent1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Further information related to the processing of the payment instruction that may need to be acted upon by the creditor's agent. The instruction may relate to a level of service, or may be an instruction that has to be executed by the creditor's agent, or may be information required by the creditor's agent.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Cd"" type=""Instruction3Code"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Coded information related to the processing of the payment instruction, provided by the initiating party, and intended for the creditor's agent.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""InstrInf"" type=""TARGET_RestrictedFINXMax140Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructionInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Further information complementing the coded instruction or instruction to the creditor's agent that is bilaterally agreed or specific to a user community.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""InstructionForNextAgent1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">InstructionForNextAgent1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Further information related to the processing of the payment instruction that may need to be acted upon by an other agent. The instruction may relate to a level of service, or may be an instruction that has to be executed by the creditor's agent, or may be information required by the other agent.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""InstrInf"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructionInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Further information complementing the coded instruction or instruction to the next agent that is bilaterally agreed or specific to a user community.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""LEIIdentifier"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">LEIIdentifier</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Legal Entity Identifier is a code allocated to a party as described in ISO 17442 ""Financial Services - Legal Entity Identifier (LEI)"".</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[A-Z0-9]{18,18}[0-9]{2,2}""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""LocalInstrument2Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">LocalInstrument2Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements that further identifies the type of local instruments being requested by the initiating party.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalLocalInstrument1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the local instrument, as published in an external local instrument code list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the local instrument, as a proprietary code.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""Max15NumericText_fixed"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Max15NumericText_fixed</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">1</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""Max35Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Max35Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 35 characters.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:minLength value=""1""/>
            <xs:maxLength value=""35""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""NameAndAddress16__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">NameAndAddress16__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a party.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which a party is known and is usually used to identify that party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Adr"" type=""PostalAddress24__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Address</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Postal address of a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""Number"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Number</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Number of objects represented as an integer.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:decimal"">
            <xs:fractionDigits value=""0""/>
            <xs:totalDigits value=""18""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""OrganisationIdentification29__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentification29__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""AnyBIC"" type=""TARGET_BIC11Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AnyBIC</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Business identification code of the organisation.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LEI"" type=""LEIIdentifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LEI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Legal entity identification as an alternate identification for a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""2"" minOccurs=""0"" name=""Othr"" type=""GenericOrganisationIdentification1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Other</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification of an organisation, as assigned by an institution, using an identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""OrganisationIdentification29__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentification29__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""AnyBIC"" type=""TARGET_BIC11Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AnyBIC</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Business identification code of the organisation.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LEI"" type=""LEIIdentifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LEI</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Legal entity identification as an alternate identification for a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""2"" minOccurs=""0"" name=""Othr"" type=""GenericOrganisationIdentification1__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Other</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification of an organisation, as assigned by an institution, using an identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""OrganisationIdentificationSchemeName1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentificationSchemeName1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Sets of elements to identify a name of the organisation identification scheme.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalOrganisationIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""OrganisationIdentificationSchemeName1Choice__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentificationSchemeName1Choice__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Sets of elements to identify a name of the organisation identification scheme.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalOrganisationIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Party38Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Party38Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Nature or use of the account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""OrgId"" type=""OrganisationIdentification29__1"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentification</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify an organisation.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""PrvtId"" type=""PersonIdentification13__1"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">PrivateIdentification</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a person, for example a passport.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Party38Choice__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Party38Choice__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Nature or use of the account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""OrgId"" type=""OrganisationIdentification29__2"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentification</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify an organisation.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""PrvtId"" type=""PersonIdentification13__2"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">PrivateIdentification</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a person, for example a passport.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Party38Choice__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Party38Choice__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Nature or use of the account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""OrgId"" type=""OrganisationIdentification29__2"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">OrganisationIdentification</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify an organisation.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""PrvtId"" type=""PersonIdentification13__3"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">PrivateIdentification</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a person, for example a passport.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PartyIdentification135__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PartyIdentification135__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the identification of a person or an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which a party is known and which is usually used to identify that party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Id"" type=""Party38Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtryOfRes"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountryOfResidence</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country in which a person resides (the place of a person's home). In the case of a company, it is the country from which the affairs of that company are directed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PartyIdentification135__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PartyIdentification135__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the identification of a person or an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which a party is known and which is usually used to identify that party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Id"" type=""Party38Choice__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtryOfRes"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountryOfResidence</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country in which a person resides (the place of a person's home). In the case of a company, it is the country from which the affairs of that company are directed.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtctDtls"" type=""Contact4__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ContactDetails</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to indicate how to contact the party.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PartyIdentification135__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PartyIdentification135__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the identification of a person or an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which a party is known and which is usually used to identify that party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Id"" type=""Party38Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtryOfRes"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountryOfResidence</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country in which a person resides (the place of a person's home). In the case of a company, it is the country from which the affairs of that company are directed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PartyIdentification135__4"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PartyIdentification135__4</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the identification of a person or an organisation.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name by which a party is known and which is usually used to identify that party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""PostalAddress24__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Id"" type=""Party38Choice__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtryOfRes"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountryOfResidence</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country in which a person resides (the place of a person's home). In the case of a company, it is the country from which the affairs of that company are directed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PaymentIdentification7__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PaymentIdentification7__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides further means of referencing a payment transaction.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""InstrId"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructionIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification, as assigned by an instructing party for an instructed party, to unambiguously identify the instruction.

Usage: The instruction identification is a point to point reference that can be used between the instructing party and the instructed party to refer to the individual instruction. It can be included in several messages related to the instruction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""EndToEndId"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">EndToEndIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification, as assigned by the initiating party, to unambiguously identify the transaction. This identification is passed on, unchanged, throughout the entire end-to-end chain.

Usage: The end-to-end identification can be used for reconciliation or to link tasks relating to the transaction. It can be included in several messages related to the transaction.

Usage: In case there are technical limitations to pass on multiple references, the end-to-end identification must be passed on throughout the entire end-to-end chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""UETR"" type=""UUIDv4Identifier"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">UETR</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Universally unique identifier to provide an end-to-end reference of a payment transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""ClrSysRef"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystemReference</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique reference, as assigned by a clearing system, to unambiguously identify the instruction.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PaymentTypeInformation28__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PaymentTypeInformation28__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides further details of the type of payment.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""InstrPrty"" type=""Priority2Code"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">InstructionPriority</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Indicator of the urgency or order of importance that the instructing party would like the instructed party to apply to the processing of the instruction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""3"" minOccurs=""0"" name=""SvcLvl"" type=""ServiceLevel8Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ServiceLevel</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Agreement under which or rules under which the transaction should be processed.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""LclInstrm"" type=""LocalInstrument2Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LocalInstrument</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">User community specific instrument.

Usage: This element is used to specify a local instrument, local clearing option and/or further qualify the service or service level.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtgyPurp"" type=""CategoryPurpose1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CategoryPurpose</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the high level purpose of the instruction based on a set of pre-defined categories.
Usage: This is used by the initiating party to provide information concerning the processing of the payment. It is likely to trigger special processing by any of the agents involved in the payment chain.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""PercentageRate"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PercentageRate</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Rate expressed as a percentage, that is, in hundredths, for example, 0.7 is 7/10 of a percent, and 7.0 is 7%.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:decimal"">
            <xs:fractionDigits value=""10""/>
            <xs:totalDigits value=""11""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""PersonIdentification13__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PersonIdentification13__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DtAndPlcOfBirth"" type=""DateAndPlaceOfBirth1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DateAndPlaceOfBirth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date and place of birth of a person.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""2"" minOccurs=""0"" name=""Othr"" type=""GenericPersonIdentification1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Other</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification of a person, as assigned by an institution, using an identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PersonIdentification13__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PersonIdentification13__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DtAndPlcOfBirth"" type=""DateAndPlaceOfBirth1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DateAndPlaceOfBirth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date and place of birth of a person.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""2"" minOccurs=""0"" name=""Othr"" type=""GenericPersonIdentification1__2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Other</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification of a person, as assigned by an institution, using an identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PersonIdentification13__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PersonIdentification13__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous way to identify a person.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DtAndPlcOfBirth"" type=""DateAndPlaceOfBirth1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DateAndPlaceOfBirth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date and place of birth of a person.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""2"" minOccurs=""0"" name=""Othr"" type=""GenericPersonIdentification1__3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Other</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification of a person, as assigned by an institution, using an identification scheme.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PersonIdentificationSchemeName1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PersonIdentificationSchemeName1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Sets of elements to identify a name of the identification scheme.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalPersonIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PersonIdentificationSchemeName1Choice__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PersonIdentificationSchemeName1Choice__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Sets of elements to identify a name of the identification scheme.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalPersonIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PersonIdentificationSchemeName1Choice__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PersonIdentificationSchemeName1Choice__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Sets of elements to identify a name of the identification scheme.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalPersonIdentification1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PostalAddress24__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress24__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dept"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Department</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a division of a large organisation or building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SubDept"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SubDepartment</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a sub-division of a large organisation or building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""StrtNm"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">StreetName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of a street or thoroughfare.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BldgNb"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BuildingNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Number that identifies the position of a building on a street.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BldgNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BuildingName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the building or house.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Flr"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Floor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Floor or storey within a building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstBx"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostBox</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Numbered box in a post office, assigned to a person or organisation, where letters are kept until called for.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Room"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Room</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Building room number.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstCd"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostCode</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifier consisting of a group of letters and/or numbers that is added to a postal address to assist the sorting of mail.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TwnNm"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TownName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of a built-up area, with defined boundaries, and a local government.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TwnLctnNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TownLocationName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specific location name within the town.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DstrctNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DistrictName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a subdivision within a country sub-division.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtrySubDvsn"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountrySubDivision</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a subdivision of a country such as state, region, county.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ctry"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Country</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Nation with its own government.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""3"" minOccurs=""0"" name=""AdrLine"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AddressLine</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services, presented in free format text.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PostalAddress24__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress24__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dept"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Department</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a division of a large organisation or building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SubDept"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SubDepartment</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a sub-division of a large organisation or building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""StrtNm"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">StreetName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of a street or thoroughfare.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BldgNb"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BuildingNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Number that identifies the position of a building on a street.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BldgNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BuildingName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the building or house.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Flr"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Floor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Floor or storey within a building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstBx"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostBox</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Numbered box in a post office, assigned to a person or organisation, where letters are kept until called for.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Room"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Room</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Building room number.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstCd"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostCode</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifier consisting of a group of letters and/or numbers that is added to a postal address to assist the sorting of mail.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""TwnNm"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TownName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of a built-up area, with defined boundaries, and a local government.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TwnLctnNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TownLocationName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specific location name within the town.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DstrctNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DistrictName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a subdivision within a country sub-division.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtrySubDvsn"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountrySubDivision</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a subdivision of a country such as state, region, county.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Ctry"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Country</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Nation with its own government.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""PostalAddress24__3"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress24__3</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information that locates and identifies a specific address, as defined by postal services.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dept"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Department</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a division of a large organisation or building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SubDept"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SubDepartment</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of a sub-division of a large organisation or building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""StrtNm"" type=""TARGET_RestrictedFINXMax70Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">StreetName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of a street or thoroughfare.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BldgNb"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BuildingNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Number that identifies the position of a building on a street.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""BldgNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">BuildingName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the building or house.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Flr"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Floor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Floor or storey within a building.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstBx"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostBox</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Numbered box in a post office, assigned to a person or organisation, where letters are kept until called for.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Room"" type=""TARGET_RestrictedFINXMax70Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Room</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Building room number.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstCd"" type=""TARGET_RestrictedFINXMax16Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostCode</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifier consisting of a group of letters and/or numbers that is added to a postal address to assist the sorting of mail.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""TwnNm"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TownName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of a built-up area, with defined boundaries, and a local government.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TwnLctnNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TownLocationName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specific location name within the town.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DstrctNm"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DistrictName</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a subdivision within a country sub-division.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtrySubDvsn"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CountrySubDivision</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies a subdivision of a country such as state, region, county.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Ctry"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Country</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Nation with its own government.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""Priority2Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Priority2Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the priority level of an event.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""HIGH"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">High</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Priority level is high.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""NORM"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Normal</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Priority level is normal.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""Priority3Code__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Priority3Code__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the priority level of an event.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""HIGH"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">High</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Priority level is high.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""NORM"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Normal</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Priority level is normal.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""ProxyAccountIdentification1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ProxyAccountIdentification1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to a proxy  identification of the account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""ProxyAccountType1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Type of the proxy identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax320Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification used to indicate the account identification under another specified name.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ProxyAccountIdentification1__2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ProxyAccountIdentification1__2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information related to a proxy  identification of the account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""ProxyAccountType1Choice"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Type of the proxy identification.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Id"" type=""TARGET_RestrictedFINXMax320Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Identification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification used to indicate the account identification under another specified name.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ProxyAccountType1Choice"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ProxyAccountType1Choice</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the scheme used for the identification of an account alias.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalProxyAccountType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""Max35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ProxyAccountType1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ProxyAccountType1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the scheme used for the identification of an account alias.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalProxyAccountType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a coded form as published in an external list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the identification scheme, in a free text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""Purpose2Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">Purpose2Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the underlying reason for the payment transaction.
Usage: Purpose is used by the end-customers, that is initiating party, (ultimate) debtor, (ultimate) creditor to provide information concerning the nature of the payment. Purpose is a content element, which is not used for processing by any of the agents involved in the payment chain.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalPurpose1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Underlying reason for the payment transaction, as published in an external purpose code list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Purpose, in a proprietary form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ReferredDocumentInformation7__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ReferredDocumentInformation7__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to identify the documents referred to in the remittance information.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""ReferredDocumentType4__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nb"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Number</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique and unambiguous identification of the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RltdDt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RelatedDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date associated with the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""LineDtls"" type=""DocumentLineInformation1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">LineDetails</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide the content of the referred document line.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ReferredDocumentType3Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ReferredDocumentType3Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the document referred in the remittance information.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""DocumentType6Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Document type in a coded form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Proprietary identification of the type of the remittance document.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""ReferredDocumentType4__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ReferredDocumentType4__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the document referred in the remittance information.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""CdOrPrtry"" type=""ReferredDocumentType3Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CodeOrProprietary</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides the type details of the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Issr"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Issuer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the issuer of the reference document type.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""RegulatoryAuthority2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RegulatoryAuthority2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Entity requiring the regulatory reporting information.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the entity requiring the regulatory reporting information.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ctry"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Country</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country of the entity that requires the regulatory reporting information.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""RegulatoryReporting3__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RegulatoryReporting3__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information needed due to regulatory and/or statutory requirements.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DbtCdtRptgInd"" type=""RegulatoryReportingType1Code"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebitCreditReportingIndicator</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies whether the regulatory reporting information applies to the debit side, to the credit side or to both debit and credit sides of the transaction.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Authrty"" type=""RegulatoryAuthority2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Authority</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Entity requiring the regulatory reporting information.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""Dtls"" type=""StructuredRegulatoryReporting3__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Details</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide details on the regulatory reporting information.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""RegulatoryReportingType1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RegulatoryReportingType1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies whether the regulatory reporting information applies to the debit side, to the credit side or to both debit and credit sides of the transaction.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""CRED"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Credit</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Regulatory information applies to the credit side.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""DEBT"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Debit</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Regulatory information applies to the debit side.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""BOTH"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Both</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Regulatory information applies to both credit and debit sides.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""RemittanceAmount2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceAmount2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Nature of the amount and currency on a document referred to in the remittance section, typically either the original amount due/payable or the amount actually remitted for the referenced document.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DuePyblAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DuePayableAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount specified is the exact amount due and payable to the creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""DscntApldAmt"" type=""DiscountAmountAndType1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DiscountAppliedAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount specified for the referred document is the amount of discount to be applied to the amount due and payable to the creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CdtNoteAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditNoteAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount specified for the referred document is the amount of a credit note.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""TaxAmt"" type=""TaxAmountAndType1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Quantity of cash resulting from the calculation of the tax.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""AdjstmntAmtAndRsn"" type=""DocumentAdjustment1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AdjustmentAmountAndReason</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies detailed information on the amount and reason of the document adjustment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RmtdAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittedAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money remitted for the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""RemittanceAmount3__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceAmount3__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Nature of the amount and currency on a document referred to in the remittance section, typically either the original amount due/payable or the amount actually remitted for the referenced document.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DuePyblAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DuePayableAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount specified is the exact amount due and payable to the creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""DscntApldAmt"" type=""DiscountAmountAndType1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DiscountAppliedAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of discount to be applied to the amount due and payable to the creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CdtNoteAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditNoteAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of a credit note.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""TaxAmt"" type=""TaxAmountAndType1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of the tax.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""AdjstmntAmtAndRsn"" type=""DocumentAdjustment1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AdjustmentAmountAndReason</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies detailed information on the amount and reason of the adjustment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RmtdAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittedAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money remitted.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""RemittanceInformation16__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceInformation16__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information supplied to enable the matching/reconciliation of an entry with the items that the payment is intended to settle, such as commercial invoices in an accounts' receivable system.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ustrd"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Unstructured</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information supplied to enable the matching/reconciliation of an entry with the items that the payment is intended to settle, such as commercial invoices in an accounts' receivable system, in an unstructured form.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Strd"" type=""StructuredRemittanceInformation16__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Structured</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Information supplied to enable the matching/reconciliation of an entry with the items that the payment is intended to settle, such as commercial invoices in an accounts' receivable system, in a structured form.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""RemittanceLocation7__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceLocation7__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the remittance advice.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RmtId"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification, as assigned by the initiating party, to unambiguously identify the remittance information sent separately from the payment instruction, such as a remittance advice.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""RmtLctnDtls"" type=""RemittanceLocationData1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceLocationDetails</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide information on the location and/or delivery of the remittance information.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""RemittanceLocationData1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceLocationData1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides additional details on the remittance advice.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""Mtd"" type=""RemittanceLocationMethod2Code"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Method</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Method used to deliver the remittance advice information.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""ElctrncAdr"" type=""TARGET_RestrictedFINXMax2048Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ElectronicAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Electronic address to which an agent is to send the remittance information.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""PstlAdr"" type=""NameAndAddress16__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">PostalAddress</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Postal address to which an agent is to send the remittance information.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""RemittanceLocationMethod2Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">RemittanceLocationMethod2Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the method used to deliver the remittance advice information.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""FAXI"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Fax</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Remittance advice information must be faxed.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""EDIC"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ElectronicDataInterchange</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Remittance advice information must be sent through Electronic Data Interchange (EDI).</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""URID"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">UniformResourceIdentifier</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Remittance advice information needs to be sent to a Uniform Resource Identifier (URI). URI is a compact string of characters that uniquely identify an abstract or physical resource. URI's are the super-set of identifiers, such as URLs, email addresses, ftp sites, etc, and as such, provide the syntax for all of the identification schemes.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""EMAL"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">EMail</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Remittance advice information must be sent through e-mail.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""POST"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Post</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Remittance advice information must be sent through postal services.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""SMSM"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SMS</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Remittance advice information must be sent through by phone as a short message service (SMS).</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""ServiceLevel8Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">ServiceLevel8Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the service level of the transaction.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalServiceLevel1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a pre-agreed service or level of service between the parties, as published in an external service level code list.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a pre-agreed service or level of service between the parties, as a proprietary code.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""SettlementDateTimeIndication1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">SettlementDateTimeIndication1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information on the occurred settlement time(s) of the payment transaction.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""CdtDtTm"" type=""TARGET_DateTime"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditDateTime</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date and time at which a payment has been credited at the transaction administrator. In the case of TARGET, the date and time at which the payment has been credited at the receiving central bank, expressed in Central European Time (CET).</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""SettlementInstruction7__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">SettlementInstruction7__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides further details on the settlement of the instruction.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element name=""SttlmMtd"" type=""SettlementMethod1Code__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SettlementMethod</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Method used to settle the (batch of) payment instructions.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""ClrSys"" type=""ClearingSystemIdentification3Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystem</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specification of a pre-agreed offering between clearing agents or the channel through which the payment instruction is processed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""SettlementMethod1Code__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">SettlementMethod1Code__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the method used to settle the credit transfer instruction.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""CLRG"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ClearingSystem</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Settlement is done through a payment clearing system.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""SettlementTimeRequest2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">SettlementTimeRequest2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the requested settlement time(s) of the payment instruction.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TillTm"" type=""TARGET_Time"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TillTime</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Time until when the payment may be settled.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""FrTm"" type=""TARGET_Time"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FromTime</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Time as from when the payment may be settled.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RjctTm"" type=""TARGET_Time"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RejectTime</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Time by when the payment must be settled to avoid rejection.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""StructuredRegulatoryReporting3__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">StructuredRegulatoryReporting3__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information needed due to regulatory and statutory requirements.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the information supplied in the regulatory reporting details.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Date</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date related to the specified type of regulatory reporting details.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ctry"" type=""CountryCode"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Country</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Country related to the specified type of regulatory reporting details.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Cd"" type=""TARGET_RestrictedFINXMax10Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the nature, purpose, and reason for the transaction to be reported for regulatory and statutory requirements in a coded form.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Amt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money to be reported for regulatory and statutory requirements.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""Inf"" type=""TARGET_RestrictedFINXMax35Text"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Information</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Additional details that cater for specific domestic regulatory requirements.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""StructuredRemittanceInformation16__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">StructuredRemittanceInformation16__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Information supplied to enable the matching/reconciliation of an entry with the items that the payment is intended to settle, such as commercial invoices in an accounts' receivable system, in a structured form.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""RfrdDocInf"" type=""ReferredDocumentInformation7__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ReferredDocumentInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides the identification and the content of the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RfrdDocAmt"" type=""RemittanceAmount2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ReferredDocumentAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides details on the amounts of the referred document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CdtrRefInf"" type=""CreditorReferenceInformation2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CreditorReferenceInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Reference information provided by the creditor to allow the identification of the underlying documents.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Invcr"" type=""PartyIdentification135__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Invoicer</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the organisation issuing the invoice, when it is different from the creditor or ultimate creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Invcee"" type=""PartyIdentification135__4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Invoicee</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the party to whom an invoice is issued, when it is different from the debtor or ultimate debtor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxRmt"" type=""TaxInformation7__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxRemittance</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides remittance information about a payment made for tax-related purposes.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""GrnshmtRmt"" type=""Garnishment3__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">GarnishmentRemittance</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides remittance information about a payment for garnishment-related purposes.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""3"" minOccurs=""0"" name=""AddtlRmtInf"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AdditionalRemittanceInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Additional information, in free text form, to complement the structured remittance information.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""TARGET_BIC11Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_BIC11Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">BIC must have exactly 11 characters</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[A-Z0-9]{4,4}[A-Z]{2,2}[A-Z0-9]{2,2}[A-Z0-9]{3,3}""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_DateTime"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_DateTime</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:dateTime"">
            <xs:pattern value="".*(\+|-)((0[0-9])|(1[0-3])):[0-5][0-9]""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_Max18_Max2DecimalAmount_SimpleType"">
        <xs:restriction base=""xs:decimal"">
            <xs:fractionDigits value=""2""/>
            <xs:totalDigits value=""18""/>
            <xs:minInclusive value=""0""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""TARGET_Max18_Max2DecimalAmount"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_Max18_Max2DecimalAmount</xs:documentation>
        </xs:annotation>
        <xs:simpleContent>
            <xs:extension base=""TARGET_Max18_Max2DecimalAmount_SimpleType"">
                <xs:attribute name=""Ccy"" type=""ActiveCurrencyCode"" use=""required"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Ccy</xs:documentation>
                    </xs:annotation>
                </xs:attribute>
            </xs:extension>
        </xs:simpleContent>
    </xs:complexType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax10Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax10Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 10 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + .</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,8}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""10""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax140Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax140Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 140 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + .</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,138}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""140""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax140Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax140Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 140 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]&#13;
</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,138}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""140""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax16Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax16Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 16 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,14}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""16""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax2048Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax2048Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 2048 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,2046}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""2048""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax28Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax28Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 28 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + .</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,26}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""28""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax30Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax30Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 30 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + .</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,28}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""30""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax320Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax320Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 320 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,318}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""320""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax34Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax34Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 34 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . and disable the use of slash ""/"" at the beginning and end of line and double slash ""//"" within the line.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,32}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""34""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax35Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax35Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 35 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ‘ + .</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,33}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""35""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax35Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax35Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 35 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]&#13;
</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,33}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""35""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax4Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax4Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 4 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,2}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""4""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax70Text"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax70Text</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 70 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + .</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+](|[0-9a-zA-Z/\-\?:\(\)\.,'\+]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ ]{1,68}[0-9a-zA-Z/\-\?:\(\)\.,'\+])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""70""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_RestrictedFINXMax70Text_Extended"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_RestrictedFINXMax70Text_Extended</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies a character string with a maximum length of 70 characters limited to character set X, that is, a-z A-Z / - ? : ( ) . , ' + . !#$%&amp;*=^_`{|}~"";&lt;&gt;@[\]</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]](|[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]|[0-9a-zA-Z/\-\?:\(\)\.,'\+ !#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]]{1,68}[0-9a-zA-Z/\-\?:\(\)\.,'\+!#$%&amp;\*=^_`\{\|\}~&quot;;&lt;&gt;@\[\\\]])""/>
            <xs:minLength value=""1""/>
            <xs:maxLength value=""70""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TARGET_Time"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TARGET_Time</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:time"">
            <xs:pattern value="".*(\+|-)((0[0-9])|(1[0-3])):[0-5][0-9]""/>
        </xs:restriction>
    </xs:simpleType>
    <xs:complexType name=""TaxAmount2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxAmount2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide information on the tax amount(s) of tax record.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Rate"" type=""PercentageRate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Rate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Rate used to calculate the tax.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxblBaseAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxableBaseAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money on which the tax is based.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TtlAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TotalAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Total amount that is the result of the calculation of the tax for the record.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""Dtls"" type=""TaxRecordDetails2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Details</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide details on the tax period and amount.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxAmountAndType1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxAmountAndType1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount with a specific type.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""TaxAmountType1Choice__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the type of the amount.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Amt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Amount of money, which has been typed.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxAmountType1Choice__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxAmountType1Choice__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount type.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:choice>
                <xs:element name=""Cd"" type=""ExternalTaxAmountType1Code"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Code</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount type, in a coded form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
                <xs:element name=""Prtry"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                    <xs:annotation>
                        <xs:documentation source=""Name"" xml:lang=""EN"">Proprietary</xs:documentation>
                        <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the amount type, in a free-text form.</xs:documentation>
                    </xs:annotation>
                </xs:element>
            </xs:choice>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxAuthorisation1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxAuthorisation1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Details of the authorised tax paying party.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Titl"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Title</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Title or position of debtor or the debtor's authorised representative.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Nm"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Name</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Name of the debtor or the debtor's authorised representative.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxInformation7__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxInformation7__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Details about tax paid, or to be paid, to the government in accordance with the law, including pre-defined parameters such as thresholds and type of account.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Cdtr"" type=""TaxParty1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Creditor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Party on the credit side of the transaction to which the tax applies.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dbtr"" type=""TaxParty2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Debtor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies the party on the debit side of the transaction to which the tax applies.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""UltmtDbtr"" type=""TaxParty2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">UltimateDebtor</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Ultimate party that owes an amount of money to the (ultimate) creditor, in this case, to the taxing authority.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""AdmstnZone"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AdministrationZone</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Territorial part of a country to which the tax payment is related.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RefNb"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ReferenceNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax reference information that is specific to a taxing agency.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Mtd"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Method</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Method used to indicate the underlying business or how the tax is paid.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TtlTaxblBaseAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TotalTaxableBaseAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Total amount of money on which the tax is based.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TtlTaxAmt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TotalTaxAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Total amount of money as result of the calculation of the tax.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Dt"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Date</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Date by which tax is due.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""SeqNb"" type=""Number"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SequenceNumber</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Sequential number of the tax report.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""unbounded"" minOccurs=""0"" name=""Rcrd"" type=""TaxRecord2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Record</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Record of tax details.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxParty1__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxParty1__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Details about the entity involved in the tax paid or to be paid.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxId"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax identification number of the creditor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RegnId"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RegistrationIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification, as assigned by an organisation, to unambiguously identify a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxTp"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxType</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Type of tax payer.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxParty2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxParty2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Details about the entity involved in the tax paid or to be paid.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxId"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax identification number of the debtor.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""RegnId"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">RegistrationIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Unique identification, as assigned by an organisation, to unambiguously identify a party.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxTp"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxType</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Type of tax payer.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Authstn"" type=""TaxAuthorisation1__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Authorisation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Details of the authorised tax paying party.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxPeriod2"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxPeriod2</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Period of time details related to the tax payment.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Yr"" type=""ISODate"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Year</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Year related to the tax payment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""TaxRecordPeriod1Code"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification of the period related to the tax payment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""FrToDt"" type=""DatePeriod2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FromToDate</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Range of time between a start date and an end date for which the tax report is provided.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxRecord2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxRecord2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to define the tax record.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Tp"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Type</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">High level code to identify the type of tax details.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Ctgy"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Category</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the tax code as published by the tax authority.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CtgyDtls"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CategoryDetails</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Provides further details of the category tax code.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""DbtrSts"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">DebtorStatus</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Code provided by local authority to identify the status of the party that has drawn up the settlement document.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""CertId"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">CertificateIdentification</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identification number of the tax report as assigned by the taxing authority.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""FrmsCd"" type=""TARGET_RestrictedFINXMax35Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FormsCode</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Identifies, in a coded form, on which template the tax report is to be provided.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Prd"" type=""TaxPeriod2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Period</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide details on the period of time related to the tax payment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""TaxAmt"" type=""TaxAmount2__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TaxAmount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide information on the amount of the tax record.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""AddtlInf"" type=""TARGET_RestrictedFINXMax140Text_Extended"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">AdditionalInformation</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Further details of the tax record.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:complexType name=""TaxRecordDetails2__1"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxRecordDetails2__1</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Provides information on the individual tax amount(s) per period of the tax record.</xs:documentation>
        </xs:annotation>
        <xs:sequence>
            <xs:element maxOccurs=""1"" minOccurs=""0"" name=""Prd"" type=""TaxPeriod2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Period</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Set of elements used to provide details on the period of time related to the tax payment.</xs:documentation>
                </xs:annotation>
            </xs:element>
            <xs:element name=""Amt"" type=""ActiveOrHistoricCurrencyAndAmount__1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">Amount</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Underlying tax amount related to the specified period.</xs:documentation>
                </xs:annotation>
            </xs:element>
        </xs:sequence>
    </xs:complexType>
    <xs:simpleType name=""TaxRecordPeriod1Code"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TaxRecordPeriod1Code</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Specifies the period related to the tax payment.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:enumeration value=""MM01"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FirstMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the second month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM02"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SecondMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the first month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM03"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ThirdMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the third month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM04"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FourthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the fourth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM05"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FifthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the fifth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM06"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SixthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the sixth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM07"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SeventhMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the seventh month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM08"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">EighthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the eighth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM09"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">NinthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the ninth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM10"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TenthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the tenth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM11"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">EleventhMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the eleventh month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""MM12"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">TwelfthMonth</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the twelfth month of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""QTR1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FirstQuarter</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the first quarter of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""QTR2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SecondQuarter</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the second quarter of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""QTR3"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">ThirdQuarter</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the third quarter of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""QTR4"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FourthQuarter</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the forth quarter of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""HLF1"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">FirstHalf</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the first half of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
            <xs:enumeration value=""HLF2"">
                <xs:annotation>
                    <xs:documentation source=""Name"" xml:lang=""EN"">SecondHalf</xs:documentation>
                    <xs:documentation source=""Definition"" xml:lang=""EN"">Tax is related to the second half of the period.</xs:documentation>
                </xs:annotation>
            </xs:enumeration>
        </xs:restriction>
    </xs:simpleType>
    <xs:simpleType name=""TrueFalseIndicator"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">TrueFalseIndicator</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">A flag indicating a True or False value.</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:boolean""/>
    </xs:simpleType>
    <xs:simpleType name=""UUIDv4Identifier"">
        <xs:annotation>
            <xs:documentation source=""Name"" xml:lang=""EN"">UUIDv4Identifier</xs:documentation>
            <xs:documentation source=""Definition"" xml:lang=""EN"">Universally Unique IDentifier (UUID) version 4, as described in IETC RFC 4122 ""Universally Unique IDentifier (UUID) URN Namespace"".</xs:documentation>
        </xs:annotation>
        <xs:restriction base=""xs:string"">
            <xs:pattern value=""[a-f0-9]{8}-[a-f0-9]{4}-4[a-f0-9]{3}-[89ab][a-f0-9]{3}-[a-f0-9]{12}""/>
        </xs:restriction>
    </xs:simpleType>
</xs:schema>";
    }

}
