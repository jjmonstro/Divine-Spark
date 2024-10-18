import connection from "../database.js";

let tableName = "Personagem";

async function getPersonagem(req,res){
  try{
    let result = await connection.query(`SELECT * FROM ${tableName};`);
    res.send(result.recordset);
    console.table(result.recordset);
    }
    catch(ex){
        console.log(ex.message);
    }
}
  
  async function getPersonagemById(req,res) {
    try{
      let result = await connection.query(`SELECT * FROM ${tableName} WHERE ID = ${req.params.id};`);
      res.send(result.recordset[0]);
      console.table(result.recordset);
      }
      catch(ex){
          console.log(ex.message);
      }
  }

export {getPersonagem, getPersonagemById}