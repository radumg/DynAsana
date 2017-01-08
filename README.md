# DynAsana
Dynamo package providing integration with Asana. 

## Asana API credentials
Access token “testing API”
0/ec3d060b02f91b6901e39ba5289136a1

## Asana API examples
### CREATE A NEW TASK
curl -H "Authorization: Bearer 0/ec3d060b02f91b6901e39ba5289136a1" \
https://app.asana.com/api/1.0/tasks \
-d "notes=This task was created using the asana API“ \
-d "name=API task“ \
-d "workspace=71290134040537"

### GET AVAILABLE WORKSPACES
curl -H "Authorization: Bearer 0/ec3d060b02f91b6901e39ba5289136a1" \
https://app.asana.com/api/1.0/workspaces

workspace for “koncepto.ro”
71290134040537

a workspace can be the organization itself, the one above is !

### GET AVAILABLE PROJECTS
curl -H "Authorization: Bearer 0/ec3d060b02f91b6901e39ba5289136a1" \
https://app.asana.com/api/1.0/projects

### GET AVAILABLE TEAMS
curl -H "Authorization: Bearer 0/ec3d060b02f91b6901e39ba5289136a1" \
https://app.asana.com/api/1.0/organizations/organization-id/teams/

curl -H "Authorization: Bearer 0/ec3d060b02f91b6901e39ba5289136a1" \
https://app.asana.com/api/1.0/organizations/71290134040537/teams/

organization-id or workspace id
