#Design Document OutLine

Requirement:
============
CoreCredit should be able show PDF Statements for Test Accounts as soon as Aging API is done for an Account.



Existing Flow for Showing Statement PDF on CoreCredit:
======================================================
	1. RD Workflow generates Statement PDF and Creates Entry in GeneratedReports Table in Replication CoreIssue DB.
	(GeneratedReports.Location column contains physical path of actual file eg.
	
	F:\ReportDelivery\\output\6-4855\4969\Statements\2018-01-10\Normal\7000000000003249_2018-01-10_289620_4.pdf

	2. Statements folder uploaded to a public folder on Corecredit webserver.

	3. on CoreCredit Statements panel WCF Service CardHolderStatementPdfPath is called to list StatementDates for which PDFs have been generated.

	[USP_CardHolderStatement] uses join between StatementHeader, ReportSchedules, GeneratedReports table to trim Location Path for selected account:
	ie
		Statements/2018-01-10/Normal/7000000000003249_2018-01-10_289620_4.pdf

	4. WCF Service CardHolderStatementPdfPath prepends public path of Statements folder i.e.

	     https://testcorecredit.corecard.com/PDFStatements/Statements/2018-01-10/Normal/7000000000003249_2018-01-10_289620_4.pdf

	5. On Corecredit, clicking on Download button, a new window is launched with URL created in Step 4.



Change in Flow for WebStatementHandler:
=======================================
	*2. Statements folder will uploaded to application/virtual directory created for WebStatementHandler.
	ie 
		http://asingh1/CC.WebStatementHandler/WebStatementHandler.ashx

	3.  Change in [USP_CardHolderStatement],

		SP will return dynamic Query string containing ReportId, Statement Date, Acctid FOR TEST ACCOUNTS
			eg
			?ReportID=327&CurrentDate=02%2F15%2F2017&AID=5026

	4. WCF Service CardHolderStatementPdfPath will prepend public path of WebStatementHandler to the QueryString returned by API in Step 3 ie

		http://asingh1/CC.WebStatementHandler/WebStatementHandler.ashx?ReportID=327&CurrentDate=02%2F15%2F2017&AID=5026
