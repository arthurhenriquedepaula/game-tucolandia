# game-tucolandia

# OBS: Não subi o jogo para o o GITHUB pois o arquivo é maior que os 25 mb suportados pelo GITHUB, portanto deixo esse link do DRIVE que contém todo o projeto desenvolvido, peço encarecidamente que considere da mesma maneira: https://drive.google.com/file/d/1tdmfdFUT95-4ZCxqcyNFoMtW8ThosQtc/view?usp=sharing

# Tucolândia: O Jogo de Sobrevivência na Cidade
Bem-vindo a Tucolândia, um emocionante jogo de sobrevivência onde cada decisão pode ser a diferença entre a vida e a morte! Em uma cidade tomada pelo caos;

Características do Jogo:
Direção de Veículos:
Veículo abandonado pode ser utilizado para andar por toda a cidade. Use as setas do teclado para dirigir e navegar pelas ruas caóticas de Tucolândia. Domine a direção para escapar dos zumbis e encontrar locais seguros.
Ambiente Imersivo:
Explore uma cidade detalhada e cheia de perigos. Desde becos escuros até ruas desertas, cada canto de Tucolândia oferece novos desafios e oportunidades de sobrevivência.

======================================================================

# Funcionalidades
Trovões:
Experimente trovoados que vão te ensurdecer repentina, adicionando um elemento atmosférico e imprevisível ao jogo. 
(Como o trovão é apenas uma funcionalidade que pode ser escutada e não apresentada por print, é possível escutar o mesmo no vídeo)

Código:
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // Luz direcional que representa o sol
    public float dayDuration = 60f; // Duração de um dia em segundos

    private float timeOfDay = 0f; // Variável que controla a passagem do tempo do dia

    void Update()
    {
        // Incrementa o tempo do dia baseado no tempo real do jogo
        timeOfDay += Time.deltaTime / dayDuration;

        // Calcula o ângulo do sol
        float sunAngle = timeOfDay * 360f;

        // Rotaciona a luz direcional para simular o movimento do sol
        // O ângulo do sol é ajustado em relação aos eixos X e Z para controlar a altura e direção
        directionalLight.transform.rotation = Quaternion.Euler(new Vector3(sunAngle - 90f, 170f, 0));

        // Reinicia o tempo do dia se ele exceder 1 (um ciclo completo)
        if (timeOfDay >= 1f)
        {
            timeOfDay = 0f;
        }
    }
}


Ciclo Dia e Noite:
A cidade não para, com um ciclo dinâmico de dia e noite que afeta a visibilidade e a agressividade dos zumbis. Planeje suas ações de acordo com o horário para maximizar suas chances de sobrevivência.

# Noite:
![noite](https://github.com/arthurhenriquedepaula/game-tucolandia/assets/81483650/d8bc56f9-4b70-414b-90e8-bc72ca638d8f)

# Dia:
![dia](https://github.com/arthurhenriquedepaula/game-tucolandia/assets/81483650/1bfc472b-70f7-4380-bd14-82e7a4b207f2)

Código:
using System.Collections;
using UnityEngine;

public class LightningManager : MonoBehaviour
{
    // Declaração de variáveis públicas para serem configuradas no inspector do Unity
    public Light lightningLight; // Luz que representa o relâmpago
    public AudioSource thunderSound; // Som do trovão
    public float minTimeBetweenLightning = 10f; // Tempo mínimo entre relâmpagos
    public float maxTimeBetweenLightning = 30f; // Tempo máximo entre relâmpagos
    public float lightningDuration = 0.2f; // Duração do flash do relâmpago

    private void Start()
    {
        // Verifica se a luz do relâmpago foi atribuída
        if (lightningLight == null)
        {
            Debug.LogError("Lightning light not assigned.");
            return; // Sai do método Start se não houver luz atribuída
        }

        // Verifica se o som do trovão foi atribuído
        if (thunderSound == null)
        {
            Debug.LogError("Thunder sound not assigned.");
            return; // Sai do método Start se não houver som atribuído
        }

        // Inicialmente, a luz do relâmpago está desativada
        lightningLight.enabled = false;
        // Inicia a corrotina que controla o relâmpago
        StartCoroutine(ControlLightning());
    }

    private IEnumerator ControlLightning()
    {
        while (true)
        {
            // Espera por um tempo aleatório antes de iniciar o próximo relâmpago
            float timeToWait = Random.Range(minTimeBetweenLightning, maxTimeBetweenLightning);
            yield return new WaitForSeconds(timeToWait);

            // Ativa o flash do relâmpago
            lightningLight.enabled = true;
            yield return new WaitForSeconds(lightningDuration); // Espera pela duração do relâmpago
            lightningLight.enabled = false; // Desativa o relâmpago

            // Reproduz o som do trovão com um atraso para simular a distância
            float thunderDelay = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(thunderDelay);
            thunderSound.Play();
        }
    }
}

======================================================================

6. Sons Ambientais:
Sons realistas e assustadores, desde o rugido de um trovão até a música ambiente do jogo.
======================================================================
Como Jogar:
Direção: Use as setas do teclado para controlar o carro. Domine a direção para escapar rapidamente dos zumbis.
Sobrevivência: Explore a cidade, onde você poderá ver uma perseguição de zumbi, em Tucolândia, a sobrevivência é uma corrida contra o tempo e os zumbis. Você tem o que é preciso para escapar e encontrar um lugar seguro? 

PRINTS:
Tela inicial:

![tela_inicio](https://github.com/arthurhenriquedepaula/game-tucolandia/assets/81483650/5004881d-118e-4270-8de3-43307d43eadd)
![carro-zumbi](https://github.com/arthurhenriquedepaula/game-tucolandia/assets/81483650/3fdbe648-4815-423d-a007-6b431c4ca6df)
![cidade](https://github.com/arthurhenriquedepaula/game-tucolandia/assets/81483650/0ceb336c-c1b7-4082-ae36-d89ae4bac02b)

# LINK do vídeo:
https://youtu.be/1AG-mfZtoSE










