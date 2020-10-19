# パッシブ修飾システム

## 生成元

```csharp
class PassiveEffectSettings
{
    // ActorAbility内のint, bool, float, stringなどのプリミティブ型が対象
    ActorAbility Ability;

    // 必ずBefore, Afterが両方作られる
    AttackBattleEvent AttackBattleEvent;
    DamageBattleEvent DamageBattleEvent;
}
```

## シンタックス

### 生成元

```bnf
<passive-decorator> ::= <namespace>
<namespace> ::= <namespace-declaration> "{" <class> "}"
<class> ::= <class-declaration>"Settings" "{" <member-list> "}"
<member-list> ::= [<parameter> | <event>]
<parameter> ::= <parameter-type> <parameter-name>
<event> ::= <event-type> <event-name>
```

### 生成先

#### パッシブ修飾クラス

```bnf
<passive-decorator> ::= <namespace>
<namespace> ::= <src.namespace-declaration> "{" <class> "}"
<class> ::= <src.class-declaration> "{" <methods> "}"
<methods> ::= [<hook> | <modifier>]
<hook> ::= "public virtual Task BeforeEventAsync("<src.event-type>" @event) => Task.CompletedTask;" "public virtual Task AfterEventAsync("<src.event-type>" @event) => Task.CompletedTask;"
<modifier> ::= "public virtual int Modify"<src.parameter-member-name>"("<src.parameter-member-type>" source) => source;"
```

#### パッシブフッククラス

```bnf
<passive-hook> ::= <namespace>
<namespace> ::= <src.namespace-declaration> "{" <class> "}"
<class> ::= <src.class-declaration> "{" <methods> "}"
<methods> ::= <before> <after>
<before> ::= "public async Task BeforeEventAsync(IPassiveDecorationProvider provider, IBattleEvent @event)" "{" <before-impl> "}"
```