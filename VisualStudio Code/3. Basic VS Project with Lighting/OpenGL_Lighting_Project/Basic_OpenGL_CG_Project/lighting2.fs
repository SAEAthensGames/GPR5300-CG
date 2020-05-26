#version 330 core
out vec4 FragColor;

struct Material {
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;    
    float shininess;
}; 

struct Light {
    vec3 position;
    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

in vec3 FragPos;  
in vec3 Normal;  
  
uniform vec3 viewPos;
uniform Material material;
uniform Light light; 

void main()
{
    // ambient
  	vec3 ambient = vec3(0.0);
    //TODO
  	
    // diffuse 
	vec3 diffuse = vec3(0.0);
    //TODO
    
    // specular
	vec3 specular = vec3(0.0);
    //TODO 
    
    vec3 result = ambient + diffuse + specular;
    FragColor = vec4(result, 1.0);
}