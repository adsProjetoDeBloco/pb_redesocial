# REDESOCIAL API

## Request URL: Identity

#### SingUp:
https://pbidentityapigerenciamento.azure-api.net/Auth/singup
Corpo da Requisição:
```json
{
  "email": "string",
  "password": "string",
  "rePassword": "string"
}
```

#### login:
https://pbidentityapigerenciamento.azure-api.net/Auth/login
```json
{
  "email": "string",
  "password": "string",
}
```

### Reset Password:
Este deve ser feito em 2 passos, primeiro devemos obter o token passando o email

https://pbidentityapigerenciamento.azure-api.net/Auth/reset-password-token
```json
{
  "email": "string",
}
```
Isto ira nós retornar StatusCode 200 com a string que será o Token, apos pegar esse token você vai passar ele você deve realizar uma nova requisição passando email, senha nova, confirmação e o token de reset:
https://pbidentityapigerenciamento.azure-api.net/reset-password

````json
    {
      "email": "user@example.com",
      "password": "string",
      "rePassword": "string",
      "token": "string"
    }
```

---

## Request URL: Social Media API:


### Usuario
* Create User:
https://socialmediaapiapipb.azure-api.net/User/adduser
Corpo da Requisição:
```json
{
  "name": "string",
  "email": "string",
  "bio": "string"
}
```


* Get User By Id:
https://socialmediaapiapipb.azure-api.net/User/getuserbyid/{id}

Retorno da Requisição:
```json
{
  "id": 1,
  "name": "Teste",
  "email": "email@teste",
  "bio": "minha bio",
  "games": [],
  "followers": [],
  "following": [],
  "posts": [
    {
      "id": 2,
      "title": "Post 2",
      "postText": "Texto do Post 2",
      "userId": 1,
      "comments": [],
      "createdAt": "2023-04-03T01:25:37.8405257"
    }
  ]
}
```


* Get All Users:
https://socialmediaapiapipb.azure-api.net/User/getallusers


Retorno da Requisição:
```json
[
  {
    "id": 1,
    "name": "Teste",
    "email": "email@teste",
    "bio": "minha bio",
    "games": [],
    "followers": [],
    "following": [],
    "posts": [
      {
        "id": 2,
        "title": "Post 2",
        "postText": "Texto do Post 2",
        "userId": 1,
        "comments": [],
        "createdAt": "2023-04-03T01:25:37.8405257"
      }
    ]
  },
  {
    "id": 2,
    "name": "Pedro",
    "email": "pedro@email.com",
    "bio": "Eu me chamo Pedro e gosto de jogar XXX jogos",
    "games": [],
    "followers": [],
    "following": [],
    "posts": [
      {
        "id": 1,
        "title": "Post 1",
        "postText": "Texto do Post",
        "userId": 2,
        "comments": [
          {
            "id": 1,
            "message": "Mensagem no Post 1 do usuario 2",
            "userId": 2,
            "postedAt": "2023-04-03T01:21:05.7516606",
            "postId": 1
          }
        ],
        "createdAt": "2023-04-03T01:20:22.1841064"
      }
    ]
  }
]
```


* Delete User:
https://socialmediaapiapipb.azure-api.net/User/deleteuser/{id}


---


### Comentarios:


* Create Comment: 
https://socialmediaapiapipb.azure-api.net/Comment/creatcomment

Corpo da requisição:
```json
{
  "message": "string",
  "userId": 0,
  "postId": 0
}
```


* Delete Comment: 
  
https://socialmediaapiapipb.azure-api.net/Comment/deletecomment/{commentId}

<b>Retorna Status 204 (No Content)</b>


* Get Comment By Id: 

https://socialmediaapiapipb.azure-api.net/Comment/getcommentbyid/{commentId}

Retorno da Requisição:
```json
{
  "id": 1,
  "message": "Mensagem no Post 1 do usuario 2",
  "userId": 2,
  "postedAt": "2023-04-03T01:21:05.7516606"
}
```

---

### Games:
* Create Game: 

https://socialmediaapiapipb.azure-api.net/Game/creategame

Corpo da Requisição:
```json
{
    "gameName":"string",
    "category":"string",
    "description":"string"
}

```
<br/>

* Delete Game: 

https://socialmediaapiapipb.azure-api.net/Game/deletegame/{id}
Corpo da Requisição:

<b>Retorna Status 204 (No Content)</b>
<br/>

* Get All Games: https://socialmediaapiapipb.azure-api.net/Game/getallgames

Retorno da Requisição:
```json
[
  {
    "id": 1,
    "gameName": "string",
    "category": "string",
    "description": "string"
  }
]
```


* Get Game By Id: 
https://socialmediaapiapipb.azure-api.net/Game/getgamebyid/{id}

Retorno da Requisição:
```json
[
  {
    "id": 1,
    "gameName": "string",
    "category": "string",
    "description": "string"
  }
]
```

* Update Game: https://socialmediaapiapipb.azure-api.net/Game/updategame


Corpo da Requisição:
```json
{
    "gameName":"string",
    "category":"string",
    "description":"string"
}
```

---

### Post:
* Create Post: https://socialmediaapiapipb.azure-api.net/Post/creatpost
Retorno da Requisição:
```json
{
    "title": "string",
    "postText": "string",
    "userId": 0
}
```


* Delete Post: https://socialmediaapiapipb.azure-api.net/Post/deletepost/{id}
  
<b>Retorna Status 204 (No Content)</b>
<br/>

* Get All Post: https://socialmediaapiapipb.azure-api.net/Post/getallposts

Retorno da Requisição:
```json
[
  {
    "id": 1,
    "title": "Post 1",
    "postText": "Texto do Post",
    "userName": "Pedro",
    "comments": [
      {
        "id": 1,
        "message": "Mensagem no Post 1 do usuario 2",
        "userId": 2,
        "postedAt": "2023-04-03T01:21:05.7516606",
        "postId": 1
      }
    ],
    "createdAt": "2023-04-03T01:20:22.1841064"
  },
  {
    "id": 2,
    "title": "Post 2",
    "postText": "Texto do Post 2",
    "userName": "Teste",
    "comments": [],
    "createdAt": "2023-04-03T01:25:37.8405257"
  }
]

```


* Get Post By Id: https://socialmediaapiapipb.azure-api.net/Post/getpostbyid/{id}
```json
{
  "id": 1,
  "title": "Post 1",
  "postText": "Texto do Post",
  "userName": "Pedro",
  "comments": [
    {
      "id": 1,
      "message": "Mensagem no Post 1 do usuario 2",
      "userId": 2,
      "postedAt": "2023-04-03T01:21:05.7516606",
      "postId": 1
    }
  ],
  "createdAt": "2023-04-03T01:20:22.1841064"
}

```


---




## Relações de dados

### Entidades:

1 - User:
* Id
* Nome
* Biografia
* Email
* Uma lista de jogos
* Uma lista de Seguidores
* Uma Lista de Grupos

2 - Follower:
* Id
* Lista de Usuarios

3 - Group:
* Id
* Nome do Grupo
* Descriçao
* Membro
* Data da Criação

4 - Game:
* Id
* Nome do Jogo
* Categoria
* Descrio

5 - Post:
* Id
* Titulo
* Texto
* Nome do usuarios que postou
* Lista de Comentarios

6 - Comments:
* Id
* Mensagen
* Nome do usuario que publicou
* data da postagem

---

## Relações concluidas:

Todos os dados foram relacionados.