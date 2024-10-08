import { Router } from "express";
import { getArma, getArmaById } from "../controller/armaController.js";
import { getBau, getBauById } from "../controller/bauController.js";
import { getMonstro, getMonstroById } from "../controller/monstroController.js";
import { getPersonagem, getPersonagemById } from "../controller/personagemController.js";
import { getPocao, getPocaoById } from "../controller/pocaoController.js";
import { getSala, getSalaById } from "../controller/salaController.js";
const router = Router();



router.get('/Arma', getArma)
router.get('/Arma/:id', getArmaById)

router.get('/Bau', getBau)
router.get('/Bau/:id', getBauById)

router.get('/Monstro', getMonstro)
router.get('/Monstro/:id', getMonstroById)

router.get('/Personagem', getPersonagem)
router.get('/Personagem/:id', getPersonagemById)

router.get('/Pocao', getPocao)
router.get('/Pocao/:id', getPocaoById)

router.get('/Sala', getSala)
router.get('/Sala/:id', getSalaById)

export default router;