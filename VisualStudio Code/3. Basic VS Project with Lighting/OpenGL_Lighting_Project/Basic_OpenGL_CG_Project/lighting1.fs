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
    float ambientCoeff = 0.1f;
	ambient = ambientCoeff * lightColor;
  	
    // diffuse 
	vec3 diffuse = vec3(0.0);
    vec3 lightDir = normalize(lightPos - FragPos);
	float diffuseCoeff = max(dot(Normal, lightDir), 0.0);
	diffuse = diffuseCoeff * lightColor;
    
    // specular
	vec3 specular = vec3(0.0);
	vec3 viewDir = normalize(viewPos - FragPos);
	
	vec3 halfwayDir = normalize(lightDir + viewDir);
    //vec3 reflectDir = reflect(-lightDir, Normal);     
	float specularCoeff = pow(max(dot(Normal, halfwayDir), 0.0), 32);
	
	if(dot(lightDir, Normal) <= 0.0)
		specularCoeff = 0.0f;
	
	specular = specularCoeff * lightColor;
		
    vec3 result = (ambient + diffuse + specular) * objectColor;
    FragColor = vec4(result, 1.0);
}