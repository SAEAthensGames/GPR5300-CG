#version 330 core
out vec4 FragColor;

struct Material {
	vec3 color;
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
    vec3 ambient = vec3(0.0);
    vec3 ambientCoeff = material.ambient;
	ambient = ambientCoeff * light.ambient;
  	
    // diffuse 
	vec3 diffuse = vec3(0.0);
    vec3 lightDir = normalize(light.position - FragPos);
	vec3 diffuseCoeff = max(dot(Normal, lightDir), 0.0) * material.diffuse;
	diffuse = diffuseCoeff * light.diffuse;
    
    // specular
	vec3 specular = vec3(0.0);
	vec3 viewDir = normalize(viewPos - FragPos);
	
	vec3 halfwayDir = normalize(lightDir + viewDir);
    //vec3 reflectDir = reflect(-lightDir, Normal);     
	vec3 specularCoeff = pow(max(dot(Normal, halfwayDir), 0.0), material.shininess) * material.specular;
	
	if(dot(lightDir, Normal) <= 0.0)
		specularCoeff = vec3(0.0f);
	
	specular = specularCoeff * light.specular;
    
    vec3 result = (ambient + diffuse + specular) * material.color;
    FragColor = vec4(result, 1.0);
}