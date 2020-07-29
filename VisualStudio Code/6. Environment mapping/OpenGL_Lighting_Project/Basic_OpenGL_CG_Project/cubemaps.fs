#version 330 core
out vec4 FragColor;

in vec3 Normal;
in vec3 Position;

uniform vec3 cameraPos;
uniform samplerCube skybox;

uniform bool useReflection;

void main()
{  
    vec3 I = normalize(Position - cameraPos);
	vec3 R1 = reflect(I, normalize(Normal));
	
	float ratio = 1.0003 / 1.03;
	vec3 R2 = refract(I, normalize(Normal), ratio);
	
	vec3 result = mix(texture(skybox, R1).rgb, texture(skybox, R2).rgb, 0.2);
	
    FragColor = vec4(result, 1.0);
}