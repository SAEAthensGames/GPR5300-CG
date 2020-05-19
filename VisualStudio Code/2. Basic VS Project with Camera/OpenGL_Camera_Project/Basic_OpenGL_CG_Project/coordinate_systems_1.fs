#version 330 core
out vec4 FragColor;

in vec2 TexCoord;
in vec4 vertexColor;

// texture sampler
uniform sampler2D texture1;

void main()
{
	//FragColor = mix(vertexColor, texture(texture1, TexCoord), 0.2);
	FragColor = texture(texture1, TexCoord);
}