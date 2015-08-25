select 
MAX(empl.DepartmentName) dep, MAX(empl.PostName) post, empl.EmplFullName,OK_Adress.Adress 
 from [dbo].[GetDepartmentStaff](1, GETDATE(),GETDATE(),1)empl
inner join dbo.OK_Adress ON empl.idEmployee=OK_Adress.idEmployee
where empl.idEmployee is not null
and
/*((OK_Adress.Adress like '%”хта%Ћенина%' 
	and (OK_Adress.Adress like '%67%к%' or OK_Adress.Adress like '%69%к%' or OK_Adress.Adress like '%71%к%' or OK_Adress.Adress like '%73%к%' or OK_Adress.Adress like '%77%к%' or OK_Adress.Adress like '%79%к%'))
or
(OK_Adress.Adress like '%”хта%Ќефт€ников%' 
	and (OK_Adress.Adress like '%12%к%' or OK_Adress.Adress like '%13%к%' or OK_Adress.Adress like '%14%к%' or OK_Adress.Adress like '%15%к%' or OK_Adress.Adress like '%16%к%' or OK_Adress.Adress like '%17%к%' or OK_Adress.Adress like '%20%к%' or OK_Adress.Adress like '%21%к%' or OK_Adress.Adress like '%22%к%' or OK_Adress.Adress like '%23%к%'))
or
(OK_Adress.Adress like '%”хта%—троителей%' 
	and (OK_Adress.Adress like '%29%к%' or OK_Adress.Adress like '%31%к%' or OK_Adress.Adress like '%33%к%' or OK_Adress.Adress like '%35%к%' or OK_Adress.Adress like '%39%к%' or OK_Adress.Adress like '%37%к%'))


((OK_Adress.Adress like '%”хта%—евастопольска€%' 
	and (OK_Adress.Adress like '%11а%к%' or OK_Adress.Adress like '%13%к%' or OK_Adress.Adress like '%13а%к%'))
or
(OK_Adress.Adress like '%”хта%—енюкова%' 
	and (OK_Adress.Adress like '%1%к%' or OK_Adress.Adress like '%3%к%' or OK_Adress.Adress like '%7%к%' or OK_Adress.Adress like '%9%к%' or OK_Adress.Adress like '%11%к%' or OK_Adress.Adress like '%25%к%'))
or
(OK_Adress.Adress like '%”хта%лет ќкт€бр€%' 
	and (OK_Adress.Adress like '%50%к%'))
or
(OK_Adress.Adress like '%”хта%л осмонавтов%' 
	and (OK_Adress.Adress like '%9%к%' or OK_Adress.Adress like '%10%к%' or OK_Adress.Adress like '%11%к%' or OK_Adress.Adress like '%13%к%' or OK_Adress.Adress like '%17%к%' or OK_Adress.Adress like '%15%к%' or OK_Adress.Adress like '%19%к%' or OK_Adress.Adress like '%19а%к%' or OK_Adress.Adress like '%21%к%' or OK_Adress.Adress like '%21а%к%' or OK_Adress.Adress like '%22%к%' or OK_Adress.Adress like '%23%к%' or OK_Adress.Adress like '%24%к%'))
or
(OK_Adress.Adress like '%”хта%ёбилейна€%' 
	and (OK_Adress.Adress like '%8%к%' or OK_Adress.Adress like '%12%к%' or OK_Adress.Adress like '%16%к%' or OK_Adress.Adress like '%18%к%' or OK_Adress.Adress like '%20%к%' or OK_Adress.Adress like '%26%к%'))
or
(OK_Adress.Adress like '%”хта%л„ибьюский%' 
	and (OK_Adress.Adress like '%3%к%' or OK_Adress.Adress like '%5%к%' or OK_Adress.Adress like '%7%к%'))

*/

(OK_Adress.Adress like '%”хта%Ћенина%' 
	and (OK_Adress.Adress like '%3%к%' or OK_Adress.Adress like '%5%к%' or OK_Adress.Adress like '%9%к%'))
or(OK_Adress.Adress like '%”хта%40 лет  оми%' 
	and (OK_Adress.Adress like '%4%к%' or OK_Adress.Adress like '%10%к%' or OK_Adress.Adress like '%12%к%' or OK_Adress.Adress like '%14%к%'))
or(OK_Adress.Adress like '%”хта%ƒзержинского%' 
	and (OK_Adress.Adress like '%1%к%' or OK_Adress.Adress like '%3%к%' or OK_Adress.Adress like '%4%к%' or OK_Adress.Adress like '%5%к%' or OK_Adress.Adress like '%6%к%' or OK_Adress.Adress like '%7%к%' or OK_Adress.Adress like '%38%к%' or OK_Adress.Adress like '%9%к%' or OK_Adress.Adress like '%10%к%' or OK_Adress.Adress like '%11%к%' or OK_Adress.Adress like '%12%к%' or OK_Adress.Adress like '%14%к%' or OK_Adress.Adress like '%20%к%' or OK_Adress.Adress like '%22%к%'))
or(OK_Adress.Adress like '%”хта%ќкт€брьска€%' 
	and (OK_Adress.Adress like '%23%к%' or OK_Adress.Adress like '%25%к%' or OK_Adress.Adress like '%27%к%' or OK_Adress.Adress like '%29%к%'))
or(OK_Adress.Adress like '%”хта%ќплеснина%' 
	and (OK_Adress.Adress like '%1%к%' or OK_Adress.Adress like '%2%к%' or OK_Adress.Adress like '%3%к%' or OK_Adress.Adress like '%5%к%' or OK_Adress.Adress like '%7%к%' or OK_Adress.Adress like '%6%к%'
		 or OK_Adress.Adress like '%8%к%' or OK_Adress.Adress like '%9%к%' or OK_Adress.Adress like '%10%к%' or OK_Adress.Adress like '%11%к%' or OK_Adress.Adress like '%12%к%'
		  or OK_Adress.Adress like '%13%к%' or OK_Adress.Adress like '%15%к%'))
or(OK_Adress.Adress like '%”хта%ѕервомайска€%' 
	and (OK_Adress.Adress like '%19%к%' or OK_Adress.Adress like '%21%к%' or OK_Adress.Adress like '%23%к%' or OK_Adress.Adress like '%25%к%' or OK_Adress.Adress like '%27%к%' or OK_Adress.Adress like '%29%к%'
	 or OK_Adress.Adress like '%30%к%' or OK_Adress.Adress like '%31%к%' or OK_Adress.Adress like '%32%к%' or OK_Adress.Adress like '%33%к%' or OK_Adress.Adress like '%34%к%'
	  or OK_Adress.Adress like '%35%к%' or OK_Adress.Adress like '%36%к%' or OK_Adress.Adress like '%38%к%' or OK_Adress.Adress like '%40%к%' or OK_Adress.Adress like '%41%к%'
	   or OK_Adress.Adress like '%42%к%' or OK_Adress.Adress like '%43%к%' or OK_Adress.Adress like '%46%к%'))
	
GROUP BY empl.EmplFullName,OK_Adress.Adress 
ORDER BY OK_Adress.Adress , dep, post

ул.—евастопольска€: д.11а, 13, 13а; 
ул.—енюкова: д. 1, 3, 7, 9, 11, 25/52;
ул. 30 лет ќкт€бр€: д. 9, 10, 11, 13, 15, 17, 19, 19а, 21, 21а, 22, 22/12, 23/14, 24; 
пр-т  осмонавтов: д.50; 
ул.ёбилейна€: д. 8, 12, 16, 18, 20, 26; 
пер.„ибьюский: д. 3, 5, 7

—аид13:14
14 округ
¬от адреса:
проспект Ћенина, дома єє 67, 69, 71, 73, 77, 79;
улицы:
Ќабережна€ Ќефт€ников, дома єє 12, 13, 14, 15, 16, 17, 20, 21, 22, 23;
проезд —троителей, дома єє 29, 31, 33, 35, 37, 39.
