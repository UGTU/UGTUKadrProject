select 
MAX(empl.DepartmentName) dep, MAX(empl.PostName) post, empl.EmplFullName,OK_Adress.Adress 
 from [dbo].[GetDepartmentStaff](1, GETDATE(),GETDATE(),1)empl
inner join dbo.OK_Adress ON empl.idEmployee=OK_Adress.idEmployee
where empl.idEmployee is not null
and
/*((OK_Adress.Adress like '%����%������%' 
	and (OK_Adress.Adress like '%67%�%' or OK_Adress.Adress like '%69%�%' or OK_Adress.Adress like '%71%�%' or OK_Adress.Adress like '%73%�%' or OK_Adress.Adress like '%77%�%' or OK_Adress.Adress like '%79%�%'))
or
(OK_Adress.Adress like '%����%����������%' 
	and (OK_Adress.Adress like '%12%�%' or OK_Adress.Adress like '%13%�%' or OK_Adress.Adress like '%14%�%' or OK_Adress.Adress like '%15%�%' or OK_Adress.Adress like '%16%�%' or OK_Adress.Adress like '%17%�%' or OK_Adress.Adress like '%20%�%' or OK_Adress.Adress like '%21%�%' or OK_Adress.Adress like '%22%�%' or OK_Adress.Adress like '%23%�%'))
or
(OK_Adress.Adress like '%����%����������%' 
	and (OK_Adress.Adress like '%29%�%' or OK_Adress.Adress like '%31%�%' or OK_Adress.Adress like '%33%�%' or OK_Adress.Adress like '%35%�%' or OK_Adress.Adress like '%39%�%' or OK_Adress.Adress like '%37%�%'))


((OK_Adress.Adress like '%����%���������������%' 
	and (OK_Adress.Adress like '%11�%�%' or OK_Adress.Adress like '%13%�%' or OK_Adress.Adress like '%13�%�%'))
or
(OK_Adress.Adress like '%����%��������%' 
	and (OK_Adress.Adress like '%1%�%' or OK_Adress.Adress like '%3%�%' or OK_Adress.Adress like '%7%�%' or OK_Adress.Adress like '%9%�%' or OK_Adress.Adress like '%11%�%' or OK_Adress.Adress like '%25%�%'))
or
(OK_Adress.Adress like '%����%��� �������%' 
	and (OK_Adress.Adress like '%50%�%'))
or
(OK_Adress.Adress like '%����%������������%' 
	and (OK_Adress.Adress like '%9%�%' or OK_Adress.Adress like '%10%�%' or OK_Adress.Adress like '%11%�%' or OK_Adress.Adress like '%13%�%' or OK_Adress.Adress like '%17%�%' or OK_Adress.Adress like '%15%�%' or OK_Adress.Adress like '%19%�%' or OK_Adress.Adress like '%19�%�%' or OK_Adress.Adress like '%21%�%' or OK_Adress.Adress like '%21�%�%' or OK_Adress.Adress like '%22%�%' or OK_Adress.Adress like '%23%�%' or OK_Adress.Adress like '%24%�%'))
or
(OK_Adress.Adress like '%����%���������%' 
	and (OK_Adress.Adress like '%8%�%' or OK_Adress.Adress like '%12%�%' or OK_Adress.Adress like '%16%�%' or OK_Adress.Adress like '%18%�%' or OK_Adress.Adress like '%20%�%' or OK_Adress.Adress like '%26%�%'))
or
(OK_Adress.Adress like '%����%����������%' 
	and (OK_Adress.Adress like '%3%�%' or OK_Adress.Adress like '%5%�%' or OK_Adress.Adress like '%7%�%'))



(OK_Adress.Adress like '%����%������%' 
	and (OK_Adress.Adress like '%3%�%' or OK_Adress.Adress like '%5%�%' or OK_Adress.Adress like '%9%�%'))
or(OK_Adress.Adress like '%����%40 ��� ����%' 
	and (OK_Adress.Adress like '%4%�%' or OK_Adress.Adress like '%10%�%' or OK_Adress.Adress like '%12%�%' or OK_Adress.Adress like '%14%�%'))
or(OK_Adress.Adress like '%����%������������%' 
	and (OK_Adress.Adress like '%1%�%' or OK_Adress.Adress like '%3%�%' or OK_Adress.Adress like '%4%�%' or OK_Adress.Adress like '%5%�%' or OK_Adress.Adress like '%6%�%' or OK_Adress.Adress like '%7%�%' or OK_Adress.Adress like '%38%�%' or OK_Adress.Adress like '%9%�%' or OK_Adress.Adress like '%10%�%' or OK_Adress.Adress like '%11%�%' or OK_Adress.Adress like '%12%�%' or OK_Adress.Adress like '%14%�%' or OK_Adress.Adress like '%20%�%' or OK_Adress.Adress like '%22%�%'))
or(OK_Adress.Adress like '%����%�����������%' 
	and (OK_Adress.Adress like '%23%�%' or OK_Adress.Adress like '%25%�%' or OK_Adress.Adress like '%27%�%' or OK_Adress.Adress like '%29%�%'))
or(OK_Adress.Adress like '%����%���������%' 
	and (OK_Adress.Adress like '%1%�%' or OK_Adress.Adress like '%2%�%' or OK_Adress.Adress like '%3%�%' or OK_Adress.Adress like '%5%�%' or OK_Adress.Adress like '%7%�%' or OK_Adress.Adress like '%6%�%'
		 or OK_Adress.Adress like '%8%�%' or OK_Adress.Adress like '%9%�%' or OK_Adress.Adress like '%10%�%' or OK_Adress.Adress like '%11%�%' or OK_Adress.Adress like '%12%�%'
		  or OK_Adress.Adress like '%13%�%' or OK_Adress.Adress like '%15%�%'))
or(OK_Adress.Adress like '%����%������������%' 
	and (OK_Adress.Adress like '%19%�%' or OK_Adress.Adress like '%21%�%' or OK_Adress.Adress like '%23%�%' or OK_Adress.Adress like '%25%�%' or OK_Adress.Adress like '%27%�%' or OK_Adress.Adress like '%29%�%'
	 or OK_Adress.Adress like '%30%�%' or OK_Adress.Adress like '%31%�%' or OK_Adress.Adress like '%32%�%' or OK_Adress.Adress like '%33%�%' or OK_Adress.Adress like '%34%�%'
	  or OK_Adress.Adress like '%35%�%' or OK_Adress.Adress like '%36%�%' or OK_Adress.Adress like '%38%�%' or OK_Adress.Adress like '%40%�%' or OK_Adress.Adress like '%41%�%'
	   or OK_Adress.Adress like '%42%�%' or OK_Adress.Adress like '%43%�%' or OK_Adress.Adress like '%46%�%')
or(OK_Adress.Adress like '%����%���������%' )

or(OK_Adress.Adress like '%����%������������%' )
or
(OK_Adress.Adress like '%����%����������%' )
or
(OK_Adress.Adress like '%����%���������%' ))*/



	
GROUP BY empl.EmplFullName,OK_Adress.Adress 
ORDER BY OK_Adress.Adress , dep, post



����� �7
�����: ����������; ��������; �������; ���������������; ��������; �����������; ������; ����; �����������, ���� �� 1, 2, 3, 4, 5, 6, 10, 15, 17, 20, 22; 
������������ ���� �� 2/6, 4, 4�, 5, 5�, 6, 6�, 6�, 7, 8, 10, 12, 14, 15, 16/12, 28; 
�������; 
��� ����� � ����������� ��� ����������� (��� �����); ��� ������ � ����������� ��� ����������� (���. �������, �������, ������).



��.���������������: �.11�, 13, 13�; 
��.��������: �. 1, 3, 7, 9, 11, 25/52;
��. 30 ��� �������: �. 9, 10, 11, 13, 15, 17, 19, 19�, 21, 21�, 22, 22/12, 23/14, 24; 
��-� �����������: �.50; 
��.���������: �. 8, 12, 16, 18, 20, 26; 
���.���������: �. 3, 5, 7

����13:14
14 �����
��� ������:
�������� ������, ���� �� 67, 69, 71, 73, 77, 79;
�����:
���������� ����������, ���� �� 12, 13, 14, 15, 16, 17, 20, 21, 22, 23;
������ ����������, ���� �� 29, 31, 33, 35, 37, 39.
