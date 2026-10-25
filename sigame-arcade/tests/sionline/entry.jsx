import React from 'react';
import ReactDOM from 'react-dom';
import HtmlContent from './HtmlContent';
import {FixtureState} from './store';
window.fixtureEvents=[];
function Host(){
 const [paused,setPaused]=React.useState(false),[answer,setAnswer]=React.useState(false);
 const src=new URL(location.href).searchParams.get('src');
 const state={room2:{stage:{isGamePaused:paused,decisionType:answer?1:0}},table:{isMediaStopped:false},ui:{isVisible:true},settings:{soundVolume:0}};
 return <FixtureState.Provider value={state}><header>SI Online · HTML-компонент клиента</header><section id="question"><HtmlContent uri={src}/></section><nav><button id="pause" onClick={()=>setPaused(true)}>Пауза</button><button id="resume" onClick={()=>setPaused(false)}>Продолжить</button><button id="answer" onClick={()=>setAnswer(true)}>Ответ</button><button id="answer-end" onClick={()=>setAnswer(false)}>Дальше</button></nav></FixtureState.Provider>;
}
ReactDOM.render(<Host/>,document.getElementById('root'));
