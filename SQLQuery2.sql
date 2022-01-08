/*select  Kategoria.KATEGORIA, Parameterek.PARAMETER_ERTEK,Keszlet.EGYSEGAR,keszlet.MENNYISEG 
	from kategoria left join  Parameterek  on Kategoria.KATEGORIA_ID=Parameterek.KATEGORIA_ID 
	left join Alkatresz on Parameterek.PARAMETER_ID=Alkatresz.ALKATRESZ_ID left join keszlet on alkatresz.ALKATRESZ_ID=Keszlet.KESZLET_ID where alkatresz.ALKATRESZ_ID=5
	select * from Kategoria*/

	/*SELECT *,[PARAMETER_SORSZAM],[PARAMETER_ERTEK],[PARAMETER_MERTEKEGYSEG] FROM [Parameterek] WHERE /*[PARAMETER_ID]=2 AND*/ [KATEGORIA_ID]=2 */
	SELECT * FROM ALKATRESZ AS A
	--LEFT JOIN Keszlet AS K ON A.ALKATRESZ_ID=K.ALKATRESZ_ID