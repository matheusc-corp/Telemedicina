# Telemedicina

## Introdução
O projeto tem como objetivo representar um sistema de telemedicina e será uma API desenvolvida em .NET com persistência no banco de dados SQL Server.
O sistema englobará entidades para médicos, especialidades, agendamentos, pacientes e créditos de consultas. Haverá endpoints para inclusão, remoção, seleção e atualização das entidades.

Médicos e especialidades terão uma relação de muitos para muitos, ou seja, um médico poderá ter várias especialiades e uma especialidade poderá ter relação com vários médicos.

Agendamentos de consultas necessitaram de um médico, um paciente e uma especialidade. O status do agendamento sempre começará como PENDENTE.

Cada paciente terá uma quantidade de créditos de consultas. Cada agendamento realizado consumirá um crédito e se for cancelado antes da finalização, o crédito deverá ser reposto.