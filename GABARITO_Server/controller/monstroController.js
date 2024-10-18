import connection from "../database.js";

let tableName = "Monstro";

async function getMonstro(req,res){
  try{
    let result = await connection.query(`SELECT * FROM ${tableName};`);
    res.send(result.recordset);
    console.table(result.recordset);
    }
    catch(ex){
        console.log(ex.message);
    }
}
  
  async function getMonstroById(req,res) {
    try{
      let result = await connection.query(`SELECT * FROM ${tableName} WHERE ID = ${req.params.id};`);
      res.send(result.recordset[0]);
      console.table(result.recordset);
      }
      catch(ex){
          console.log(ex.message);
      }
  }

export {getMonstro, getMonstroById}