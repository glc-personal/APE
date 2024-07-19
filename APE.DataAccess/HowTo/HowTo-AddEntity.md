# HowTo-AddEntity

## Summary
This HowTo goes into adding an entity to represent an *APE.Core* concrete class (e.g. *Protocol*). These enties
are necessary to keep the concrete classes loosely coupled (Entity Framework would require the concrete classes (e.g. 
*Protocol* to use things like *User* rather than *IUser*)).

## Content
- Notes
- Create Entity
- Add Mapping Profile

### Notes
In the APE solution, the entity shall be prefixed by the concrete class it represent, for example, if our
concrete class is *Protocol*, the entity representing it for the SQL database is *ProtocolEntity*.

### Create Entity
All entity classes shall be placed in *APE.DataAccess.Entities* and they don't need an interface. As mentioned in the 
**Notes** section, each entity shall be prefixed by the name of the concrete class and end with *Entity*. The entity shall
take explicit concrete classes instead of interfaces for the attributes.

### Add Mapping Profile
Each entity shall be placed in the *MappingProfile*, located at *APE.DataAccess*. For example, for the *User* and it's 
corresponding entity (*UserEntity*) would be:
```
CreateMap<UserEntity, Entity>().ReverseMap();
```
The mapping profile can then be used in the corresponding repository.