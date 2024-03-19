<div align="center"> 

![header](https://capsule-render.vercel.app/api?type=Slice&text=)

##### 플레이어와 몬스터간의 스크립트 공유표
|오브젝트|CS|CS|CS|CS|CS|
|:---:|:---:|:---:|:---:|:---:|:---:|
|플레이어|Look_range|Anime|Fallow_target|Serach_target|Obj_Control|
|몬스터|Attack|Anime|Fallow_target|Serach_target|Obj_Control|

<br/>
<br/>

##### ▶ Look_range
###### 가장 가까운 적 개체가 탐지범위 안에 들어올 경우 Lookat하고 공격범위 안에 들어올 경우 공격을 실행

##### ▶ Attack
###### 공격범위 안에 들어올 경우 공격을 실행

##### ▶ Anime
###### Animator 관련 함수를 실행하기 위한 중간다리 역할

##### ▶ Fallow_target
###### Nav를 활용한 타겟의 추격

##### ▶ Serach_target
###### Physics.OverlapSphere를 활용한 가장 가까운 개체의 탐지

</div>





