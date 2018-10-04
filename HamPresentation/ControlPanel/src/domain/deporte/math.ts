export class Matematicas {
    ///par =true, impar=false
    public parImpar(valor:number)
    {
        const tipo=(valor%2)===1?false:true;
		return tipo;
	}
}