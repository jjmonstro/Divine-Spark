import db from "../database.js";

async function getPersonagem(req,res){
    let connection;
    try {
      connection = await db.connect();
      const request = await db.request();
      const results = await request.query("SELECT * FROM Personagem;");
      res.status(200).json(results);
    } catch (err) {
      console.log(err.message)
      res.status(500).json( err );
    } finally {
      connection.close();
    }
  }
  
  async function getPersonagemById(req,res) {
    try {
      connection = await db.connect();
      const request = await db.request();
      const results = await request.query(`SELECT * FROM Personagem p WHERE p.id = ${req.params.id};`);
      res.status(200).json(results);
    } catch (err) {
      console.log(err.message)
      res.status(500).json( err );
    } finally {
      connection.close();
    }
    
  }

export {getPersonagem, getPersonagemById}