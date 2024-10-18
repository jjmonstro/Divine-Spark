import connection from "../database.js";

let tableName = "Bau";

async function getBau(req,res){
  try{
    let result = await connection.query(`SELECT * FROM ${tableName};`);
    res.send(result.recordset);
    console.table(result.recordset);
    }
    catch(ex){
        console.log(ex.message);
    }
}
  
  async function getBauById(req,res) {
    try{
      let result = await connection.query(`SELECT * FROM ${tableName} WHERE ID = ${req.params.id};`);
      res.send(result.recordset[0]);
      console.table(result.recordset);
      }
      catch(ex){
          console.log(ex.message);
      }
  }
export {getBau, getBauById}