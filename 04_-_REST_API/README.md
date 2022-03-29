# Instructions for Rest-API
1. Read all persons : https://localhost:44376/api/person GET
2. Read all of a person's interests: https://localhost:44376/api/interest/1 GET *=1 is for personID
3. Read all of a person's weblinks: https://localhost:44376/api/weblink/p1  GET *=1 is for personID
4. Create a new interest for a person https://localhost:44376/api/interest/p1 POST A raw JSON with title+text and description+text
5. Create a new weblink for a person and an interest https://localhost:44376/api/weblink/p1/i1 POST A raw JSON with linkurl+text
