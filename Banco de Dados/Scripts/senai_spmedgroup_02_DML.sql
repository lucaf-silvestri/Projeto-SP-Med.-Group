USE SP_MEDICAL_GROUP;
GO

INSERT INTO tipoUsuario (tipoUsuario)
VALUES('Administrador'),('Médico'),('Cliente');
GO

INSERT INTO usuario (idTipoUsuario, email, senha)
VALUES
(1, 'fernandostrada@gmail.com', 'fernandostrada123'),
(3, 'ligia@gmail.com', 'ligia123'),
(3, 'alexandre@gmail.com', 'alexandre123'),
(3, 'fernando@gmail.com', 'fernando123'),
(3, 'henrique@gmail.com', 'henrique123'),
(3, 'joao@hotmail.com', 'joao123'),
(3, 'bruno@gmail.com', 'bruno123'),
(3, 'mariana@outlook.com', 'mariana123'),
(2, 'ricardo.lemos@spmedicalgroup.com.br', 'ricardolemos123'),
(2, 'roberto.possarle@spmedicalgroup.com.br', 'robertopossarle123'),
(2, 'helena.souza@spmedicalgroup.com.br', 'helenasouza123');
GO

INSERT INTO cliente (idUsuario, nomeCliente, dataNascCliente, telefoneCliente, rgCliente, cpfCliente, enderecoCliente) 
VALUES
(2, 'Ligia', '13/10/1983', '11 3456-7654', '43522543-5', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
(3, 'Alexandre', '23/7/2001', '11 98765-6543', '32654345-7', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
(4, 'Fernando', '10/10/1978', '11 97208-4453', '54636525-3', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
(5, 'Henrique', '13/10/1985', '11 3456-6543', '54366362-5', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
(6, 'João', '27/8/1975', '11 7656-6377', '53254444-1', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
(7, 'Bruno', '21/3/1972', '11 95436-8769', '54566266-7', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001'),
(8, 'Mariana', '05/03/2018', null, '54566266-8', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');
GO

INSERT INTO especialidadeMedico (nomeEspecialidade, descricaoEspecialidade)
VALUES
('Acupuntura', 'Terapia que consiste na aplicação de agulhas em pontos específicos do corpo para tratar doenças e para promover saúde.'),
('Anestesiologia', 'Proporciona ausência ou alívio da dor ao paciente ao realizar procedimentos médicos, como cirurgias.'),
('Angiologia', 'Estudo, diagnóstico e tratamento clínico das doenças vasculares.'),
('Cardiologia', 'Cardiologia é a especialidade médica que se ocupa do diagnóstico e tratamento das doenças que acometem o coração bem como os outros componentes do sistema circulatório. O médico especialista nessa área é o cardiologista. Um dos exames mais comumente realizados, feito por rotina, durante uma consulta de cardiologia é o eletrocardiograma, que deverá ser interpretado e laudado pelo cardiologista.'),
('Cirurgia Cardiovascular', 'A cirurgia cardiovascular é realizada para o tratamento de doenças do coração, como as cardiopatias congênitas, doenças das artérias coronarianas, da aorta e seus ramos, das válvulas cardíacas, da fibrilação atrial (arritmia) e insuficiência cardíaca.'),
('Cirurgia da Mão', 'Cirurgia da mão é uma especialidade médica que se ocupa da prevenção, diagnóstico, tratamento e reabilitação das patologias que acometem as mãos.'),
('Cirurgia do aparelho digestivo', 'A cirurgia do aparelho digestivo é uma especialidade médica que cuida do sistema digestivo, o que inclui esôfago, estômago, vesícula biliar, pâncreas, fígado e toda a extensão dos intestinos além do cólon, reto e ânus.'),
('Cirurgia geral', 'Cirurgia geral é a especialidade médica cuja área de atuação compreende: Cirurgia Abdominal, Cirurgia videolaparoscópica e Cirurgia do trauma. Esta especialidade médica ocupa-se do estudo dos mecanismo fisiopatológicos, diagnóstico e tratamento de enfermidades passíveis de abordagem por procedimentos cirúrgicos.'),
('Cirurgia pediátrica', 'A Cirurgia Pediátrica é a especialidade médica responsável pelo tratamento cirúrgico de doenças congênitas ou adquiridas, desde o período neonatal até o fim da puberdade.'),
('Cirurgia plástica', 'A cirurgia plástica é uma das mais de 50 especialidades médicas reconhecidas pelo Conselho Federal de Medicina e pela Associação Médica Brasileira.'),
('Cirurgia torácica', 'A cirurgia torácica é uma especialidade médica que trata das intervenções no tórax (tecidos, ossos e músculos) e no sistema respiratório (traquéia, brônquios, pulmões, pleuras e mediastino), para tratar diversos tipos de enfermidades, como o câncer de pulmão.'),
('Cirurgia vascular', 'A cirurgia vascular é um dos ramos da medicina em que são tratados os vasos sanguíneos — sistema linfático, artérias e veias.'),
('Dermatologia', 'Dermatologia é a especialidade médica que se ocupa do diagnóstico e tratamento clínico-cirúrgico das enfermidades relacionados à pele e aos anexos cutâneos (unhas, pelos, mucosas, cabelos). Dentro da dermatologia, existe a dermatovenerologia, especialidade que tem importante atuação no contexto das infecções sexualmente transmissíveis.'),
('Radioterapia', 'É um tratamento no qual se utilizam radiações ionizantes (raio X, por exemplo) para destruir um tumor ou impedir que suas células aumentem. Estas radiações não são vistas e durante a aplicação o paciente não sente nada. A radioterapia pode ser usada em combinação com a quimioterapia ou outros tratamentos.'),
('Urologia', 'A Urologia é uma especialidade médica dedicada ao estudo e tratamento de doenças do aparelho urinário (rins, ureter e bexiga) de homens e mulheres e de enfermidades que acometem o aparelho genital masculino (próstata, testículos e pênis).'),
('Pediatria', 'Trata-se da especialidade médica dedicada a atender recém-nascidos, crianças e adolescentes nos seus diversos aspectos, sejam eles preventivos ou curativos. O maior objetivo dessa especialidade é auxiliar a família no processo de estabelecimento da saúde infantil.'),
('Psiquiatria', 'Psiquiatria é uma das especialidades da Medicina, e basicamente é responsável pelo diagnóstico e tratamento dos chamados Transtornos Mentais e de Comportamento, atuando com a prevenção, o diagnóstico, o tratamento e a reabilitação dos diferentes modos de manifestações das doenças mentais em geral. São exemplos destas: a depressão, o transtorno bipolar, a esquizofrenia, a demência e os transtornos de ansiedade.');
GO

INSERT INTO clinica (enderecoClinica, horarioInicio, horarioFim, cnpj, nomeFantasia, razaoSocial)
VALUES
('Av. Barão Limeira, 532, São Paulo, SP', '08:00', '20:00', '86.400.902/0001-30', 'Clinica Possarle' , 'SP Medical Group')
GO

INSERT INTO medico (idUsuario, idEspecialidadeMedico, idClinica, crmMedico, nomeMedico)
VALUES 
(9, 2, 1, '54356-SP', 'Ricardo Lemos'),
(10, 17, 1,	'53452-SP',	'Roberto Possarle'),
(11, 16, 1,	'65463-SP',	'Helena Strada');
GO

INSERT INTO situacao (tipoSituacao)
VALUES 
('Agendada'),
('Realizada'),
('Cancelada');
GO

INSERT INTO consulta (idCliente, idMedico, idSituacao,	dataConsulta)
VALUES
(7,	3,	2,	'20/01/2020 15:00'),
(2,	2,	3,	'06/01/2020 10:00'),	
(3,	2,	2,	'07/02/2020 11:00'),	
(2,	2,	2,	'06/02/2018 10:00'),	
(4, 1,	3,	'07/02/2019 11:00'),	
(7,	3,	1,	'08/03/2020 15:00'),	
(4,	1,	1,	'09/03/2020 11:00');	
GO