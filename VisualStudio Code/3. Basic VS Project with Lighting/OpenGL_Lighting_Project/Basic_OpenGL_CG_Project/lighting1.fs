#version 330 core
out vec4 FragColor;

in vec3 Normal;  
in vec3 FragPos;  
  
uniform vec3 lightPos; 
uniform vec3 viewPos; 
uniform vec3 lightColor;
uniform vec3 objectColor;

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
        
    vec3 result = (ambient + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
}